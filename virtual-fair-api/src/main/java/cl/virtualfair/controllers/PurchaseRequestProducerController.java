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
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestHeader;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import cl.virtualfair.models.virtualfair.Contract;
import cl.virtualfair.models.virtualfair.EventLog;
import cl.virtualfair.models.virtualfair.PurchaseRequest;
import cl.virtualfair.models.virtualfair.PurchaseRequestProducer;
import cl.virtualfair.models.virtualfair.PurchaseRequestProduct;
import cl.virtualfair.models.virtualfair.SessionToken;
import cl.virtualfair.models.virtualfair.User;
import cl.virtualfair.services.virtualfair.ContractService;
import cl.virtualfair.services.virtualfair.EventLogService;
import cl.virtualfair.services.virtualfair.PurchaseRequestProducerService;
import cl.virtualfair.services.virtualfair.PurchaseRequestProductService;
import cl.virtualfair.services.virtualfair.PurchaseRequestService;
import cl.virtualfair.services.virtualfair.SessionTokenService;
import cl.virtualfair.services.virtualfair.UserService;
import io.swagger.annotations.ApiOperation;

@RestController
@RequestMapping("/api/PurchaseRequestProducer/")
@CrossOrigin
public class PurchaseRequestProducerController {

	@Autowired
	private UserService userService;
	
	@Autowired
	private PurchaseRequestProducerService purchaseRequestProducerService;
	
	@Autowired
	private PurchaseRequestProductService purchaseRequestProductService;
	
	@Autowired
	private PurchaseRequestService purchaseRequestService;
	
	@Autowired 
	private ContractService contractService;
	
	@Autowired
	private SessionTokenService sessionTokenService;
	
	@Autowired
	private EventLogService eventLogService;

	@ApiOperation(value = "Servicio para obtener una lista de todos los productores que estan participando en la solicitud de compra por IdPurchaseRequest")
	@GetMapping("findByIdPurchaseRequest/{idPurchaseRequest}")
	public ResponseEntity<Map<String, Object>> findByIdPurchaseRequest(@RequestHeader(name = "Authorization", required = true)String token, @PathVariable("idPurchaseRequest") long idPurchaseRequest, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User user = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && user != null && user.getStatus() == 1) {
			
				List<PurchaseRequestProducer> purchaseRequestProducers = purchaseRequestProducerService.findByIdPurchaseRequest(idPurchaseRequest);
				
				if(purchaseRequestProducers.size() > 0) {

					EventLog eventLog = new EventLog();
					
					eventLog.setIdEventType(1);
					eventLog.setIdUser(sessionToken.getIdUser());
					eventLog.setHost(httpServletRequest.getRemoteAddr());
					eventLog.setHttpMethod(httpServletRequest.getMethod());
					eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
					eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
					
					eventLogService.create(eventLog);
					
					map.put("purchaseRequestProducers", purchaseRequestProducers);
					map.put("countRows", purchaseRequestProducers.size());
					map.put("statusCode", HttpStatus.OK.value());
					
					return ResponseEntity.ok().body(map);
					
				}else {

					map.put("purchaseRequestProducers", purchaseRequestProducers);
					map.put("countRows", purchaseRequestProducers.size());
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

	@ApiOperation(value = "Servicio para obtener una lista de todos los productores ganadores de la participación de la solicitud de compra por IdPurchaseRequest (No Calcula)")
	@GetMapping("findByIdPurchaseRequestAndIsParticipantEqualToOne/{idPurchaseRequest}")
	public ResponseEntity<Map<String, Object>> findByIdPurchaseRequestAndIsParticipantEqualToOne(@RequestHeader(name = "Authorization", required = true)String token, @PathVariable("idPurchaseRequest") long idPurchaseRequest, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User user = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && user != null && user.getStatus() == 1) {
			
				List<PurchaseRequestProducer> purchaseRequestProducers = purchaseRequestProducerService.findByIdPurchaseRequestAndIsParticipantEqualToOne(idPurchaseRequest);
				
				if(purchaseRequestProducers.size() > 0) {

					EventLog eventLog = new EventLog();
					
					eventLog.setIdEventType(1);
					eventLog.setIdUser(sessionToken.getIdUser());
					eventLog.setHost(httpServletRequest.getRemoteAddr());
					eventLog.setHttpMethod(httpServletRequest.getMethod());
					eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
					eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
					
					eventLogService.create(eventLog);
					
					map.put("purchaseRequestProducers", purchaseRequestProducers);
					map.put("countRows", purchaseRequestProducers.size());
					map.put("statusCode", HttpStatus.OK.value());
					
					return ResponseEntity.ok().body(map);
					
				}else {

					map.put("purchaseRequestProducers", purchaseRequestProducers);
					map.put("countRows", purchaseRequestProducers.size());
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

	@ApiOperation(value = "Servicio para saber si el productor es participante ganador de una solicitud de compra por IdPurchaseRequest y por IdProducer")
	@GetMapping("findByIdPurchaseRequestAndIdProducerAndIsParticipantEqualToOne/{idPurchaseRequest}/{idProducer}")
	public ResponseEntity<Map<String, Object>> findByIdPurchaseRequestAndIdProducerAndIsParticipantEqualToOne(@RequestHeader(name = "Authorization", required = true)String token, @PathVariable("idPurchaseRequest") long idPurchaseRequest, @PathVariable("idProducer") long idProducer, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User user = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && user != null && user.getIdProfile() == 3 && user.getStatus() == 1) {
			
				List<PurchaseRequestProducer> purchaseRequestProducers = purchaseRequestProducerService.findByIdPurchaseRequestAndIdProducerAndIsParticipantEqualToOne(idPurchaseRequest, idProducer);
				
				if(purchaseRequestProducers.size() > 0) {

					EventLog eventLog = new EventLog();
					
					eventLog.setIdEventType(1);
					eventLog.setIdUser(sessionToken.getIdUser());
					eventLog.setHost(httpServletRequest.getRemoteAddr());
					eventLog.setHttpMethod(httpServletRequest.getMethod());
					eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
					eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
					
					eventLogService.create(eventLog);
					
					map.put("result", true);
					map.put("statusCode", HttpStatus.OK.value());
					
					return ResponseEntity.ok().body(map);
					
				}else {

					map.put("result", false);
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
	
	@ApiOperation(value = "Servicio para obtener una lista de la participación del productor que estan participando en la solicitud de compra por IdPurchaseRequest y por IdProducer")
	@GetMapping("findByIdPurchaseRequestAndIdProducer/{idPurchaseRequest}/{idProducer}")
	public ResponseEntity<Map<String, Object>> findByIdPurchaseRequestAndIdProducer(@RequestHeader(name = "Authorization", required = true)String token, @PathVariable("idPurchaseRequest") long idPurchaseRequest, @PathVariable("idProducer") long idProducer, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User user = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && user != null && user.getIdProfile() == 3 && user.getStatus() == 1) {
			
				List<PurchaseRequestProducer> purchaseRequestProducers = purchaseRequestProducerService.findByIdPurchaseRequestAndIdProducer(idPurchaseRequest, idProducer);
				
				if(purchaseRequestProducers.size() > 0) {

					EventLog eventLog = new EventLog();
					
					eventLog.setIdEventType(1);
					eventLog.setIdUser(sessionToken.getIdUser());
					eventLog.setHost(httpServletRequest.getRemoteAddr());
					eventLog.setHttpMethod(httpServletRequest.getMethod());
					eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
					eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
					
					eventLogService.create(eventLog);
					
					map.put("purchaseRequestProducers", purchaseRequestProducers);
					map.put("countRows", purchaseRequestProducers.size());
					map.put("statusCode", HttpStatus.OK.value());
					
					return ResponseEntity.ok().body(map);
					
				}else {

					map.put("purchaseRequestProducers", purchaseRequestProducers);
					map.put("countRows", purchaseRequestProducers.size());
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
	
	@ApiOperation(value = "Servicio para obtener una lista de todos los productores ganadores de la participación de la solicitud de compra por IdPurchaseRequest (Calcula)")
	@GetMapping("getParticipantsByIdPurchaseRequest/{idPurchaseRequest}")
	public ResponseEntity<Map<String, Object>> getParticipantsByIdPurchaseRequest(@RequestHeader(name = "Authorization", required = true)String token, @PathVariable("idPurchaseRequest") long idPurchaseRequest, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User user = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && user != null && user.getIdProfile() == 1 && user.getStatus() == 1) {
			
				List<PurchaseRequestProducer> purchaseRequestProducers = purchaseRequestProducerService.getParticipantsByIdPurchaseRequest(idPurchaseRequest);
				
				if(purchaseRequestProducers.size() > 0) {

					EventLog eventLog = new EventLog();
					
					eventLog.setIdEventType(1);
					eventLog.setIdUser(sessionToken.getIdUser());
					eventLog.setHost(httpServletRequest.getRemoteAddr());
					eventLog.setHttpMethod(httpServletRequest.getMethod());
					eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
					eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
					
					eventLogService.create(eventLog);
					
					map.put("purchaseRequestProducers", purchaseRequestProducers);
					map.put("countRows", purchaseRequestProducers.size());
					map.put("statusCode", HttpStatus.OK.value());
					
					return ResponseEntity.ok().body(map);
					
				}else {

					map.put("purchaseRequestProducers", purchaseRequestProducers);
					map.put("countRows", purchaseRequestProducers.size());
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
	
	@ApiOperation(value = "Servicio para crear masivamente la participación de un productor")
	@PostMapping("createMassive")
	public ResponseEntity<Map<String, Object>> createMassive(@RequestHeader(name = "Authorization", required = true)String token, @RequestBody List<PurchaseRequestProducer> purchaseRequestProducers, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User user = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && user != null && user.getIdProfile() == 3 && user.getStatus() == 1) {
			
				if(purchaseRequestProducers.size() == 0) {
					
					map.put("message", "La cantidad mínima para participar es 1.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}else {
					
					long idPurchaseRequestProduct = purchaseRequestProducers.get(0).getIdPurchaseRequestProduct();
					
					PurchaseRequestProduct purchaseRequestProduct = purchaseRequestProductService.findById(idPurchaseRequestProduct);
					
					if(purchaseRequestProduct != null) {
						
						PurchaseRequest purchaseRequest = purchaseRequestService.findById(purchaseRequestProduct.getIdPurchaseRequest());
					
						if(purchaseRequest != null) {
						
							if(purchaseRequest.getIdPurchaseRequestType() == 2) {
								
								Contract contract = contractService.findByIdUserAndIsValidEqualToOne(user.getId());
								
								if(contract != null) {
									
									for (PurchaseRequestProducer purchaseRequestProducer : purchaseRequestProducers) {
										
										if(purchaseRequestProducer.getIdPurchaseRequestProduct() != null && purchaseRequestProducer.getIdProducer() != null && purchaseRequestProducer.getPrice() != null && purchaseRequestProducer.getWeight() != null) {
											
											PurchaseRequestProducer purchaseRequestProducerExisting = purchaseRequestProducerService.findByIdPurchaseRequestProductAndIdProducer(purchaseRequestProducer.getIdPurchaseRequestProduct(), purchaseRequestProducer.getIdProducer());
											
											if(purchaseRequestProducerExisting == null) {
												
												purchaseRequestProducerService.create(purchaseRequestProducer);
												
											}
										}
										
									}
									
									EventLog eventLog = new EventLog();
									
									eventLog.setIdEventType(1);
									eventLog.setIdUser(sessionToken.getIdUser());
									eventLog.setHost(httpServletRequest.getRemoteAddr());
									eventLog.setHttpMethod(httpServletRequest.getMethod());
									eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
									eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
									
									eventLogService.create(eventLog);
									
									map.put("message", "Tus cambios se han guardado con éxito.");
									map.put("statusCode", HttpStatus.CREATED.value());
								
									return ResponseEntity.ok().body(map);
									
								}else {
									
									map.put("message", "El contrato para poder participar de una solicitud de compra hacia el extranjero no es válido.");
									map.put("statusCode", HttpStatus.NOT_FOUND.value());
								
									return ResponseEntity.ok().body(map);
									
								}
								
							}else {
							
								for (PurchaseRequestProducer purchaseRequestProducer : purchaseRequestProducers) {
									
									if(purchaseRequestProducer.getIdPurchaseRequestProduct() != null && purchaseRequestProducer.getIdProducer() != null && purchaseRequestProducer.getPrice() != null && purchaseRequestProducer.getWeight() != null) {
										
										PurchaseRequestProducer purchaseRequestProducerExisting = purchaseRequestProducerService.findByIdPurchaseRequestProductAndIdProducer(purchaseRequestProducer.getIdPurchaseRequestProduct(), purchaseRequestProducer.getIdProducer());
										
										if(purchaseRequestProducerExisting == null) {
											
											purchaseRequestProducerService.create(purchaseRequestProducer);
											
										}
									}
									
								}
								
								EventLog eventLog = new EventLog();
								
								eventLog.setIdEventType(1);
								eventLog.setIdUser(sessionToken.getIdUser());
								eventLog.setHost(httpServletRequest.getRemoteAddr());
								eventLog.setHttpMethod(httpServletRequest.getMethod());
								eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
								eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
								
								eventLogService.create(eventLog);
								
								map.put("message", "Tus cambios se han guardado con éxito.");
								map.put("statusCode", HttpStatus.CREATED.value());
							
								return ResponseEntity.ok().body(map);
								
							}
							
						}else {
							
							map.put("message", "La solicitud de compra no existe.");
							map.put("statusCode", HttpStatus.NOT_FOUND.value());
						
							return ResponseEntity.ok().body(map);
							
						}
						
					}else {
						
						map.put("message", "El producto de la solicitud de compra no existe.");
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
	
	@ApiOperation(value = "Servicio para eliminar la participación de un productor por IdPurchaseRequest y por IdProducer")
	@DeleteMapping("destroyByIdPurchaseRequestAndIdProducer/{idPurchaseRequest}/{idProducer}")
	public ResponseEntity<Map<String, Object>> destroyByIdPurchaseRequestAndIdProducer(@RequestHeader(name = "Authorization", required = true)String token, @PathVariable("idPurchaseRequest")long idPurchaseRequest, @PathVariable("idProducer")long idProducer, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User user = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && user != null && user.getIdProfile() == 3 && user.getStatus() == 1) {
			
				List<PurchaseRequestProducer> purchaseRequestProducers = purchaseRequestProducerService.findByIdPurchaseRequestAndIdProducer(idPurchaseRequest, idProducer);
				
				if(purchaseRequestProducers.size() > 0) {
					
					for (PurchaseRequestProducer purchaseRequestProducer : purchaseRequestProducers) {
						
						purchaseRequestProducerService.destroyById(purchaseRequestProducer.getId());
						
					}
					
					EventLog eventLog = new EventLog();
					
					eventLog.setIdEventType(1);
					eventLog.setIdUser(sessionToken.getIdUser());
					eventLog.setHost(httpServletRequest.getRemoteAddr());
					eventLog.setHttpMethod(httpServletRequest.getMethod());
					eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
					eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
					
					eventLogService.create(eventLog);
					
					map.put("message", "Participaciones descartadas con éxito.");
					map.put("statusCode", HttpStatus.OK.value());
				
					return ResponseEntity.ok().body(map);
					
				}else {
					
					map.put("message", "No hay participaciones para descartar.");
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
}
