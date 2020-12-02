package cl.virtualfair.controllers;

import java.util.HashMap;
import java.util.Map;

import javax.servlet.http.HttpServletRequest;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestHeader;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import cl.virtualfair.models.virtualfair.EventLog;
import cl.virtualfair.models.virtualfair.PurchaseRequest;
import cl.virtualfair.models.virtualfair.PurchaseRequestRemark;
import cl.virtualfair.models.virtualfair.SessionToken;
import cl.virtualfair.models.virtualfair.User;
import cl.virtualfair.services.virtualfair.EventLogService;
import cl.virtualfair.services.virtualfair.PurchaseRequestRemarkService;
import cl.virtualfair.services.virtualfair.PurchaseRequestService;
import cl.virtualfair.services.virtualfair.SessionTokenService;
import cl.virtualfair.services.virtualfair.UserService;
import io.swagger.annotations.ApiOperation;

@RestController
@RequestMapping("/api/PurchaseRequestRemark/")
@CrossOrigin
public class PurchaseRequestRemarkController {

	@Autowired
	private UserService userService;
	
	@Autowired
	private PurchaseRequestRemarkService purchaseRequestRemarkService;
	
	@Autowired
	private PurchaseRequestService purchaseRequestService;
	
	@Autowired
	private SessionTokenService sessionTokenService;
	
	@Autowired
	private EventLogService eventLogService;
	
	@ApiOperation(value = "Servicio para crear un nuevo comentario para una solicitud de compra")
	@PostMapping("create")
	public ResponseEntity<Map<String, Object>> create(@RequestHeader(name = "Authorization", required = true)String token, @RequestBody PurchaseRequestRemark purchaseRequestRemark, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User user = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && user != null && (user.getIdProfile() == 1 || user.getIdProfile() == 5 || user.getIdProfile() == 6) && user.getStatus() == 1) {
			
				if(purchaseRequestRemark.getIdPurchaseRequestStatus() == null) {
					
					map.put("message", "El IdPurchaseRequestStatus es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}else if(purchaseRequestRemark.getIdPurchaseRequest() == null) {
					
					map.put("message", "El IdPurchaseRequest es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}else {
					
					PurchaseRequestRemark purchaseRequestRemarkExisting = purchaseRequestRemarkService.findByIdPurchaseRequestStatusAndIdPurchaseRequest(purchaseRequestRemark.getIdPurchaseRequestStatus(), purchaseRequestRemark.getIdPurchaseRequest());
					
					if(purchaseRequestRemarkExisting == null) {
						
						purchaseRequestRemark = purchaseRequestRemarkService.create(purchaseRequestRemark);
						
						if(purchaseRequestRemark != null && purchaseRequestRemark.getId() != 0) {
							
							PurchaseRequest purchaseRequest = purchaseRequestService.findById(purchaseRequestRemark.getIdPurchaseRequest());
							
							if(purchaseRequest != null) {
								
								purchaseRequest.setIdPurchaseRequestStatus(purchaseRequestRemark.getIdPurchaseRequestStatus());
								
								purchaseRequestService.updateStatusById(purchaseRequest);
								
							}
							
							EventLog eventLog = new EventLog();
							
							eventLog.setIdEventType(1);
							eventLog.setIdUser(sessionToken.getIdUser());
							eventLog.setHost(httpServletRequest.getRemoteAddr());
							eventLog.setHttpMethod(httpServletRequest.getMethod());
							eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
							eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
							
							eventLogService.create(eventLog);
							
							map.put("message", "El comentario se registró con éxito.");
							map.put("statusCode", HttpStatus.CREATED.value());
						
							return ResponseEntity.ok().body(map);
							
						}else {
						
							map.put("message", "Hubo un problema al intentar registrar el comentario, Inténtalo de nuevo.");
							map.put("statusCode", HttpStatus.NOT_FOUND.value());
						
							return ResponseEntity.ok().body(map);
							
						}
						
					}else {
						
						map.put("message", "Comentario ya existe.");
						map.put("statusCode", HttpStatus.CONFLICT.value());
					
						return ResponseEntity.ok().body(map);
						
					}
				}
				
			}else {

				map.put("message", "Token no Permitido.");
				map.put("statusCode", HttpStatus.FORBIDDEN.value());
			
				return ResponseEntity.ok().body(map);
				
			}
			
		}catch(Exception exception) {
			
			EventLog eventLog = new EventLog();
			
			eventLog.setIdEventType(2);
			eventLog.setHost(httpServletRequest.getRemoteAddr());
			eventLog.setHttpMethod(httpServletRequest.getMethod());
			eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
			eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
			eventLog.setMessage(exception.getMessage());
			
			eventLogService.create(eventLog);
			
			map.put("message", exception.getMessage());
			map.put("statusCode", HttpStatus.INTERNAL_SERVER_ERROR.value());
			
			return ResponseEntity.ok().body(map);
			
		}
	}
}
