package cl.virtualfair.controllers;

import java.util.HashMap;
import java.util.Map;

import javax.servlet.http.HttpServletRequest;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestHeader;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import cl.virtualfair.models.virtualfair.EventLog;
import cl.virtualfair.models.virtualfair.SessionToken;
import cl.virtualfair.models.virtualfair.User;
import cl.virtualfair.services.other.ReportService;
import cl.virtualfair.services.virtualfair.EventLogService;
import cl.virtualfair.services.virtualfair.SessionTokenService;
import cl.virtualfair.services.virtualfair.UserService;
import io.swagger.annotations.ApiOperation;

@RestController
@RequestMapping("/api/Report/")
@CrossOrigin
public class ReportController {

	@Autowired
	private ReportService reportService;
	
	@Autowired
	private UserService userService;
	
	@Autowired
	private SessionTokenService sessionTokenService;
	
	@Autowired
	private EventLogService eventLogService;
	
	@ApiOperation(value = "Servicio para mandar reporte a todos los participantes por IdPurchaseRequest")
	@GetMapping("sendReportToParticipantsByIdPurchaseRequest/{idPurchaseRequest}")
	public ResponseEntity<Map<String, Object>> sendReportToParticipantsByIdPurchaseRequest(@RequestHeader(name = "Authorization", required = true)String token, @PathVariable("idPurchaseRequest")long idPurchaseRequest, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User user = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && user != null && user.getIdProfile() == 1 && user.getStatus() == 1) {
			
				Boolean existsParticipants = reportService.existsParticipantsByIdPurchaseRequest(idPurchaseRequest);
				
				if(existsParticipants) {
				
					Boolean result = reportService.sendReportToParticipantsByIdPurchaseRequest(idPurchaseRequest);
					
					if(result) {

						EventLog eventLog = new EventLog();
						
						eventLog.setIdEventType(1);
						eventLog.setIdUser(sessionToken.getIdUser());
						eventLog.setHost(httpServletRequest.getRemoteAddr());
						eventLog.setHttpMethod(httpServletRequest.getMethod());
						eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
						eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
						
						eventLogService.create(eventLog);
						
						map.put("message", "El reporte se envió con éxito");
						map.put("statusCode", HttpStatus.OK.value());
						
						return ResponseEntity.ok().body(map);
						
					}else {

						map.put("message", "Hubo un problema al intentar enviar el reporte, Inténtalo de nuevo.");
						map.put("statusCode", HttpStatus.NOT_FOUND.value());
					
						return ResponseEntity.ok().body(map);
					}
					
				}else {
					
					map.put("message", "No existen participantes para enviar reporte.");
					map.put("statusCode", HttpStatus.NOT_FOUND.value());
				
					return ResponseEntity.ok().body(map);
					
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
