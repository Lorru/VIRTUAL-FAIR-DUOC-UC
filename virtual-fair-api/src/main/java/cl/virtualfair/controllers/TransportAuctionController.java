package cl.virtualfair.controllers;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.servlet.http.HttpServletRequest;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestHeader;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import cl.virtualfair.models.virtualfair.EventLog;
import cl.virtualfair.models.virtualfair.SessionToken;
import cl.virtualfair.models.virtualfair.TransportAuction;
import cl.virtualfair.models.virtualfair.User;
import cl.virtualfair.services.virtualfair.EventLogService;
import cl.virtualfair.services.virtualfair.SessionTokenService;
import cl.virtualfair.services.virtualfair.TransportAuctionService;
import cl.virtualfair.services.virtualfair.UserService;

@RestController
@RequestMapping("/api/TransportAuction/")
@CrossOrigin
public class TransportAuctionController {

	@Autowired
	private UserService userService;
	
	@Autowired
	private TransportAuctionService transportAuctionService;
	
	@Autowired
	private SessionTokenService sessionTokenService;
	
	@Autowired
	private EventLogService eventLogService;
	
	@GetMapping("findAll")
	public ResponseEntity<Map<String, Object>> findAll(@RequestHeader(name = "Authorization", required = true)String token, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User user = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && user != null && user.getIdProfile() == 1 && user.getStatus() == 1) {
			
				List<TransportAuction> transportAuctions = transportAuctionService.findAll();
				
				if(transportAuctions.size() > 0) {

					EventLog eventLog = new EventLog();
					
					eventLog.setIdEventType(1);
					eventLog.setIdUser(sessionToken.getIdUser());
					eventLog.setHost(httpServletRequest.getRemoteAddr());
					eventLog.setHttpMethod(httpServletRequest.getMethod());
					eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
					eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
					
					eventLogService.create(eventLog);
					
					map.put("transportAuctions", transportAuctions);
					map.put("countRows", transportAuctions.size());
					map.put("statusCode", HttpStatus.OK.value());
					
					return ResponseEntity.ok().body(map);
					
				}else {

					map.put("transportAuctions", transportAuctions);
					map.put("countRows", transportAuctions.size());
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
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
	
	@GetMapping("findByIsPublicEqualToOne")
	public ResponseEntity<Map<String, Object>> findByIsPublicEqualToOne(@RequestHeader(name = "Authorization", required = true)String token, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User user = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && user != null && user.getIdProfile() == 4 && user.getStatus() == 1) {
			
				List<TransportAuction> transportAuctions = transportAuctionService.findByIsPublicEqualToOne();
				
				if(transportAuctions.size() > 0) {

					EventLog eventLog = new EventLog();
					
					eventLog.setIdEventType(1);
					eventLog.setIdUser(sessionToken.getIdUser());
					eventLog.setHost(httpServletRequest.getRemoteAddr());
					eventLog.setHttpMethod(httpServletRequest.getMethod());
					eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
					eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
					
					eventLogService.create(eventLog);
					
					map.put("transportAuctions", transportAuctions);
					map.put("countRows", transportAuctions.size());
					map.put("statusCode", HttpStatus.OK.value());
					
					return ResponseEntity.ok().body(map);
					
				}else {

					map.put("transportAuctions", transportAuctions);
					map.put("countRows", transportAuctions.size());
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
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
	
	@GetMapping("findByIdCarrierAndIsPublicEqualToOne/{idCarrier}")
	public ResponseEntity<Map<String, Object>> findByIdCarrierAndIsPublicEqualToOne(@RequestHeader(name = "Authorization", required = true)String token, @PathVariable("idCarrier") long idCarrier, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User user = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && user != null && user.getIdProfile() == 4 && user.getStatus() == 1) {
			
				List<TransportAuction> transportAuctions = transportAuctionService.findByIdCarrierAndIsPublicEqualToOne(idCarrier);
				
				if(transportAuctions.size() > 0) {

					EventLog eventLog = new EventLog();
					
					eventLog.setIdEventType(1);
					eventLog.setIdUser(sessionToken.getIdUser());
					eventLog.setHost(httpServletRequest.getRemoteAddr());
					eventLog.setHttpMethod(httpServletRequest.getMethod());
					eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
					eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
					
					eventLogService.create(eventLog);
					
					map.put("transportAuctions", transportAuctions);
					map.put("countRows", transportAuctions.size());
					map.put("statusCode", HttpStatus.OK.value());
					
					return ResponseEntity.ok().body(map);
					
				}else {

					map.put("transportAuctions", transportAuctions);
					map.put("countRows", transportAuctions.size());
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
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
	
	@PostMapping("create")
	public ResponseEntity<Map<String, Object>> create(@RequestHeader(name = "Authorization", required = true)String token, @RequestBody TransportAuction transportAuction, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User user = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && user != null && user.getIdProfile() == 1 && user.getStatus() == 1) {
			
				if(transportAuction.getIdPurchaseRequest() == null) {
					
					map.put("message", "El IdPurchaseRequest es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}else {

					transportAuction = transportAuctionService.create(transportAuction);
					
					if(transportAuction != null && transportAuction.getId() != 0) {
						
						EventLog eventLog = new EventLog();
						
						eventLog.setIdEventType(1);
						eventLog.setIdUser(sessionToken.getIdUser());
						eventLog.setHost(httpServletRequest.getRemoteAddr());
						eventLog.setHttpMethod(httpServletRequest.getMethod());
						eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
						eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
						
						eventLogService.create(eventLog);
						
						map.put("message", "Se registro la subasta con exito.");
						map.put("statusCode", HttpStatus.CREATED.value());
					
						return ResponseEntity.ok().body(map);
						
					}else {

						map.put("message", "Hubo un problema al intentar registrar la subasta, Inténtalo de nuevo.");
						map.put("statusCode", HttpStatus.NOT_FOUND.value());
					
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
	
	@PutMapping("updateIsPublicById/{id}")
	public ResponseEntity<Map<String, Object>> updateIsPublicById(@RequestHeader(name = "Authorization", required = true)String token, @PathVariable("id") long id, @RequestBody TransportAuction transportAuction, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User user = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && user != null && user.getIdProfile() == 1 && user.getStatus() == 1) {
			
				if(transportAuction.getId() == null) {
					
					map.put("message", "El Id es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}
				else if(transportAuction.getIsPublic() == null) {
					
					map.put("message", "El IsPublic es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}else {
					
					TransportAuction transportAuctionExisting = transportAuctionService.findById(id);
					
					if(transportAuctionExisting != null) {
					
						TransportAuction transportAuctionUpdated = transportAuctionService.updateIsPublicById(transportAuction);
						
						if(transportAuctionUpdated != null) {
							
							EventLog eventLog = new EventLog();
							
							eventLog.setIdEventType(1);
							eventLog.setIdUser(sessionToken.getIdUser());
							eventLog.setHost(httpServletRequest.getRemoteAddr());
							eventLog.setHttpMethod(httpServletRequest.getMethod());
							eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
							eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
							
							eventLogService.create(eventLog);
							
							map.put("message", "La subasta se actualizo con éxito.");
							map.put("statusCode", HttpStatus.OK.value());
						
							return ResponseEntity.ok().body(map);
							
						}else {
							
							map.put("message", "Hubo un problema al intentar actualizar la subasta, Inténtalo de nuevo.");
							map.put("statusCode", HttpStatus.NOT_FOUND.value());
						
							return ResponseEntity.ok().body(map);
							
						}
						
					}else {

						map.put("message", "La solicitud de compra no existe.");
						map.put("statusCode", HttpStatus.NOT_FOUND.value());
					
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
