package cl.virtualfair.controllers;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.servlet.http.HttpServletRequest;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestHeader;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import cl.virtualfair.models.virtualfair.Contract;
import cl.virtualfair.models.virtualfair.EventLog;
import cl.virtualfair.models.virtualfair.SessionToken;
import cl.virtualfair.models.virtualfair.User;
import cl.virtualfair.services.virtualfair.ContractService;
import cl.virtualfair.services.virtualfair.EventLogService;
import cl.virtualfair.services.virtualfair.SessionTokenService;
import cl.virtualfair.services.virtualfair.UserService;

@RestController
@RequestMapping("/api/Contract/")
@CrossOrigin
public class ContractController {

	@Autowired
	private ContractService contractService;
	
	@Autowired
	private UserService userService;
	
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
			
				List<Contract> contracts = contractService.findAll();
				
				if(contracts.size() > 0) {

					EventLog eventLog = new EventLog();
					
					eventLog.setIdEventType(1);
					eventLog.setIdUser(sessionToken.getIdUser());
					eventLog.setHost(httpServletRequest.getRemoteAddr());
					eventLog.setHttpMethod(httpServletRequest.getMethod());
					eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
					eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
					
					eventLogService.create(eventLog);
					
					map.put("contracts", contracts);
					map.put("countRows", contracts.size());
					map.put("statusCode", HttpStatus.OK.value());
					
					return ResponseEntity.ok().body(map);
					
				}else {

					map.put("contracts", contracts);
					map.put("countRows", contracts.size());
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
	public ResponseEntity<Map<String, Object>> create(@RequestHeader(name = "Authorization", required = true)String token, @RequestBody Contract contract, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User userExisting = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && userExisting  != null && userExisting.getIdProfile() == 1 && userExisting.getStatus() == 1) {
			
				if(contract.getIdUser() == null) {
					
					map.put("message", "El IdUser es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}else if(contract.getExpirationDate() == null) {
					
					map.put("message", "El ExpirationDate es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}else if(contract.getIsValid() == null) {
					
					map.put("message", "El IsValid es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}else {
				
					Contract contractExisting = contractService.findByIdUser(contract.getIdUser());
					
					if(contractExisting == null) {
						
						contract = contractService.create(contract);
						
						if(contract != null && contract.getId() != 0) {
							
							EventLog eventLog = new EventLog();
							
							eventLog.setIdEventType(1);
							eventLog.setIdUser(sessionToken.getIdUser());
							eventLog.setHost(httpServletRequest.getRemoteAddr());
							eventLog.setHttpMethod(httpServletRequest.getMethod());
							eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
							eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
							
							eventLogService.create(eventLog);
							
							map.put("message", "El contrato se ha registrado con éxito.");
							map.put("statusCode", HttpStatus.CREATED.value());
						
							return ResponseEntity.ok().body(map);
							
						}else {

							map.put("message", "Hubo un problema al intentar registrar el contrato, Inténtalo de nuevo.");
							map.put("statusCode", HttpStatus.NOT_FOUND.value());
						
							return ResponseEntity.ok().body(map);
							
						}
						
					}else {
					
						map.put("message", "Contrato ya existe.");
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
	
	@PutMapping("updateById/{id}")
	public ResponseEntity<Map<String, Object>> updateById(@RequestHeader(name = "Authorization", required = true)String token, @PathVariable("id") long id, @RequestBody Contract contract, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User userExisting = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && userExisting  != null && userExisting .getIdProfile() == 1 && userExisting .getStatus() == 1) {

				if(contract.getId() == null) {
					
					map.put("message", "El Id es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}
				else if(contract.getIdUser() == null) {
					
					map.put("message", "El IdUser es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}else if(contract.getExpirationDate() == null) {
					
					map.put("message", "El ExpirationDate es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}else if(contract.getIsValid() == null) {
					
					map.put("message", "El IsValid es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}else {
				
					Contract contractExistingId = contractService.findById(id);
					
					if(contractExistingId != null) {
					
						Contract contractExisting = contractService.findByIdUser(contract.getIdUser());
						
						if(contractExisting == null || contractExisting.getId() == id) {
							
							Contract contractUpdated = contractService.updateById(contract);
							
							if(contractUpdated != null) {
								
								EventLog eventLog = new EventLog();
								
								eventLog.setIdEventType(1);
								eventLog.setIdUser(sessionToken.getIdUser());
								eventLog.setHost(httpServletRequest.getRemoteAddr());
								eventLog.setHttpMethod(httpServletRequest.getMethod());
								eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
								eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
								
								eventLogService.create(eventLog);
								
								map.put("message", "El contrato se actualizo con éxito.");
								map.put("statusCode", HttpStatus.OK.value());
							
								return ResponseEntity.ok().body(map);
								
							}else {

								map.put("message", "Hubo un problema al intentar actualizar el contrato, Inténtalo de nuevo..");
								map.put("statusCode", HttpStatus.NOT_FOUND.value());
							
								return ResponseEntity.ok().body(map);
								
							}
							
						}else {
						
							map.put("message", "Contrato ya existe.");
							map.put("statusCode", HttpStatus.CONFLICT.value());
						
							return ResponseEntity.ok().body(map);
							
						}
						
					}else {

						map.put("message", "El contrato no existe.");
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
	
	@DeleteMapping("destroyById/{id}")
	public ResponseEntity<Map<String, Object>> destroyById(@RequestHeader(name = "Authorization", required = true)String token, @PathVariable("id") long id, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User user = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && user  != null && user.getIdProfile() == 1 && user.getStatus() == 1) {

				Contract contractExisting = contractService.findById(id);
				
				if(contractExisting != null) {
				
					Contract contractDestroyed = contractService.destroyById(id);
					
					if(contractDestroyed == null) {
						
						EventLog eventLog = new EventLog();
						
						eventLog.setIdEventType(1);
						eventLog.setIdUser(sessionToken.getIdUser());
						eventLog.setHost(httpServletRequest.getRemoteAddr());
						eventLog.setHttpMethod(httpServletRequest.getMethod());
						eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
						eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
						
						eventLogService.create(eventLog);
						
						map.put("message", "El contrato se elimino con éxito.");
						map.put("statusCode", HttpStatus.OK.value());
					
						return ResponseEntity.ok().body(map);
						
					}else {

						map.put("message", "Hubo un problema al intentar eliminar el contrato, Inténtalo de nuevo..");
						map.put("statusCode", HttpStatus.NOT_FOUND.value());
					
						return ResponseEntity.ok().body(map);
						
					}
					
				}else {

					map.put("message", "El contrato no existe.");
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
