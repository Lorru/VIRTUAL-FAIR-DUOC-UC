package cl.virtualfair.controllers;

import java.util.ArrayList;
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
@RequestMapping("/api/PurchaseRequest/")
@CrossOrigin
public class PurchaseRequestController {

	@Autowired
	private UserService userService;
	
	@Autowired
	private PurchaseRequestService purchaseRequestService;
	
	@Autowired
	private PurchaseRequestProductService purchaseRequestProductService;
	
	@Autowired
	private PurchaseRequestProducerService purchaseRequestProducerService;
	
	@Autowired
	private ContractService contractService;
	
	@Autowired
	private SessionTokenService sessionTokenService;
	
	@Autowired
	private EventLogService eventLogService;

	@ApiOperation(value = "Servicio para obtener una lista de todas las solicitudes de compra")
	@GetMapping("findAll")
	public ResponseEntity<Map<String, Object>> findAll(@RequestHeader(name = "Authorization", required = true)String token, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User user = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && user != null && user.getIdProfile() == 1 && user.getStatus() == 1) {
			
				List<PurchaseRequest> purchaseRequests = purchaseRequestService.findAll();
				
				if(purchaseRequests.size() > 0) {

					EventLog eventLog = new EventLog();
					
					eventLog.setIdEventType(1);
					eventLog.setIdUser(sessionToken.getIdUser());
					eventLog.setHost(httpServletRequest.getRemoteAddr());
					eventLog.setHttpMethod(httpServletRequest.getMethod());
					eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
					eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
					
					eventLogService.create(eventLog);
					
					map.put("purchaseRequests", purchaseRequests);
					map.put("countRows", purchaseRequests.size());
					map.put("statusCode", HttpStatus.OK.value());
					
					return ResponseEntity.ok().body(map);
					
				}else {

					map.put("purchaseRequests", purchaseRequests);
					map.put("countRows", purchaseRequests.size());
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
	
	@ApiOperation(value = "Servicio para obtener una lista de todas las solicitudes de compra publicadas")
	@GetMapping("findByIsPublicEqualToOne")
	public ResponseEntity<Map<String, Object>> findByIsPublicEqualToOne(@RequestHeader(name = "Authorization", required = true)String token, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User user = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && user != null && user.getIdProfile() == 1 && user.getStatus() == 1) {
			
				List<PurchaseRequest> purchaseRequests = purchaseRequestService.findByIsPublicEqualToOne();
				
				if(purchaseRequests.size() > 0) {

					EventLog eventLog = new EventLog();
					
					eventLog.setIdEventType(1);
					eventLog.setIdUser(sessionToken.getIdUser());
					eventLog.setHost(httpServletRequest.getRemoteAddr());
					eventLog.setHttpMethod(httpServletRequest.getMethod());
					eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
					eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
					
					eventLogService.create(eventLog);
					
					map.put("purchaseRequests", purchaseRequests);
					map.put("countRows", purchaseRequests.size());
					map.put("statusCode", HttpStatus.OK.value());
					
					return ResponseEntity.ok().body(map);
					
				}else {

					map.put("purchaseRequests", purchaseRequests);
					map.put("countRows", purchaseRequests.size());
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
	
	@ApiOperation(value = "Servicio para obtener una lista de todas las solicitudes de compra que no estan publicadas")
	@GetMapping("findByIsPublicEqualToZero")
	public ResponseEntity<Map<String, Object>> findByIsPublicEqualToZero(@RequestHeader(name = "Authorization", required = true)String token, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User user = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && user != null && user.getIdProfile() == 1 && user.getStatus() == 1) {
			
				List<PurchaseRequest> purchaseRequests = purchaseRequestService.findByIsPublicEqualToZero();
				
				if(purchaseRequests.size() > 0) {

					EventLog eventLog = new EventLog();
					
					eventLog.setIdEventType(1);
					eventLog.setIdUser(sessionToken.getIdUser());
					eventLog.setHost(httpServletRequest.getRemoteAddr());
					eventLog.setHttpMethod(httpServletRequest.getMethod());
					eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
					eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
					
					eventLogService.create(eventLog);
					
					map.put("purchaseRequests", purchaseRequests);
					map.put("countRows", purchaseRequests.size());
					map.put("statusCode", HttpStatus.OK.value());
					
					return ResponseEntity.ok().body(map);
					
				}else {

					map.put("purchaseRequests", purchaseRequests);
					map.put("countRows", purchaseRequests.size());
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
	
	@ApiOperation(value = "Servicio para obtener una lista de todas las solicitudes de compra por IdPurchaseRequestStatus y por IdPurchaseRequestType")
	@GetMapping("findByIdPurchaseRequestStatusAndIdPurchaseRequestType/{idPurchaseRequestStatus}/{idPurchaseRequestType}")
	public ResponseEntity<Map<String, Object>> findByIdPurchaseRequestStatusAndIdPurchaseRequestType(@RequestHeader(name = "Authorization", required = true)String token, @PathVariable("idPurchaseRequestStatus") long idPurchaseRequestStatus, @PathVariable("idPurchaseRequestType") long idPurchaseRequestType, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User user = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && user != null && user.getIdProfile() == 1 && user.getStatus() == 1) {
			
				List<PurchaseRequest> purchaseRequests = purchaseRequestService.findByIdPurchaseRequestStatusAndIdPurchaseRequestType(idPurchaseRequestStatus, idPurchaseRequestType);
				
				if(purchaseRequests.size() > 0) {

					EventLog eventLog = new EventLog();
					
					eventLog.setIdEventType(1);
					eventLog.setIdUser(sessionToken.getIdUser());
					eventLog.setHost(httpServletRequest.getRemoteAddr());
					eventLog.setHttpMethod(httpServletRequest.getMethod());
					eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
					eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
					
					eventLogService.create(eventLog);
					
					map.put("purchaseRequests", purchaseRequests);
					map.put("countRows", purchaseRequests.size());
					map.put("statusCode", HttpStatus.OK.value());
					
					return ResponseEntity.ok().body(map);
					
				}else {

					map.put("purchaseRequests", purchaseRequests);
					map.put("countRows", purchaseRequests.size());
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
	
	@ApiOperation(value = "Servicio para obtener una lista de todas las solicitudes de compra publicadas, la cual esta participando el productor, por IdPurchaseRequestType y por IdProducer")
	@GetMapping("findByIdPurchaseRequestTypeAndIdProducerAndIsPublicEqualToOne/{idPurchaseRequestType}/{idProducer}")
	public ResponseEntity<Map<String, Object>> findByIdPurchaseRequestTypeAndIdProducerAndIsPublicEqualToOne(@RequestHeader(name = "Authorization", required = true)String token, @PathVariable("idPurchaseRequestType") long idPurchaseRequestType, @PathVariable("idProducer") long idProducer, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User user = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && user != null && user.getIdProfile() == 3 && user.getStatus() == 1) {
			
				List<PurchaseRequest> purchaseRequests = purchaseRequestService.findByIdPurchaseRequestTypeAndIdProducerAndIsPublicEqualToOne(idPurchaseRequestType, idProducer);
				
				if(purchaseRequests.size() > 0) {

					EventLog eventLog = new EventLog();
					
					eventLog.setIdEventType(1);
					eventLog.setIdUser(sessionToken.getIdUser());
					eventLog.setHost(httpServletRequest.getRemoteAddr());
					eventLog.setHttpMethod(httpServletRequest.getMethod());
					eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
					eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
					
					eventLogService.create(eventLog);
					
					map.put("purchaseRequests", purchaseRequests);
					map.put("countRows", purchaseRequests.size());
					map.put("statusCode", HttpStatus.OK.value());
					
					return ResponseEntity.ok().body(map);
					
				}else {

					map.put("purchaseRequests", purchaseRequests);
					map.put("countRows", purchaseRequests.size());
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
	
	@ApiOperation(value = "Servicio para obtener una lista de todas las solicitudes de compra publicidas por IdPurchaseRequestType")
	@GetMapping("findByIdPurchaseRequestTypeAndIsPublicEqualToOne/{idPurchaseRequestType}")
	public ResponseEntity<Map<String, Object>> findByIdPurchaseRequestTypeAndIsPublicEqualToOne(@RequestHeader(name = "Authorization", required = true)String token, @PathVariable("idPurchaseRequestType") long idPurchaseRequestType, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User user = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && user != null && user.getIdProfile() == 3 && user.getStatus() == 1) {
			
				List<PurchaseRequest> purchaseRequests = purchaseRequestService.findByIdPurchaseRequestTypeAndIsPublicEqualToOne(idPurchaseRequestType);
				
				if(purchaseRequests.size() > 0) {

					EventLog eventLog = new EventLog();
					
					eventLog.setIdEventType(1);
					eventLog.setIdUser(sessionToken.getIdUser());
					eventLog.setHost(httpServletRequest.getRemoteAddr());
					eventLog.setHttpMethod(httpServletRequest.getMethod());
					eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
					eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
					
					eventLogService.create(eventLog);
					
					map.put("purchaseRequests", purchaseRequests);
					map.put("countRows", purchaseRequests.size());
					map.put("statusCode", HttpStatus.OK.value());
					
					return ResponseEntity.ok().body(map);
					
				}else {

					map.put("purchaseRequests", purchaseRequests);
					map.put("countRows", purchaseRequests.size());
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
	
	@ApiOperation(value = "Servicio para obtener una lista de todas las solicitudes de compra la cual el cliente ha creado, por IdClient")
	@GetMapping("findByIdClient/{idClient}")
	public ResponseEntity<Map<String, Object>> findByIdClient(@RequestHeader(name = "Authorization", required = true)String token, @PathVariable("idClient") long idClient, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User user = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && user != null && (user.getIdProfile() == 5 || user.getIdProfile() == 6) && user.getStatus() == 1) {
			
				List<PurchaseRequest> purchaseRequests = purchaseRequestService.findByIdClient(idClient);
				
				if(purchaseRequests.size() > 0) {

					EventLog eventLog = new EventLog();
					
					eventLog.setIdEventType(1);
					eventLog.setIdUser(sessionToken.getIdUser());
					eventLog.setHost(httpServletRequest.getRemoteAddr());
					eventLog.setHttpMethod(httpServletRequest.getMethod());
					eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
					eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
					
					eventLogService.create(eventLog);
					
					map.put("purchaseRequests", purchaseRequests);
					map.put("countRows", purchaseRequests.size());
					map.put("statusCode", HttpStatus.OK.value());
					
					return ResponseEntity.ok().body(map);
					
				}else {

					map.put("purchaseRequests", purchaseRequests);
					map.put("countRows", purchaseRequests.size());
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

	@ApiOperation(value = "Servicio para crear compra de saldo")
	@PostMapping("createBalancePurchaseRequest")
	public ResponseEntity<Map<String, Object>> createBalancePurchaseRequest(@RequestHeader(name = "Authorization", required = true)String token, @RequestBody PurchaseRequest purchaseRequest, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User user = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && user != null && user.getIdProfile() == 5 && user.getStatus() == 1) {
			
				if(purchaseRequest.getIdClient() == null) {
					
					map.put("message", "El IdClient es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}else if(purchaseRequest.getDesiredDate() == null) {
					
					map.put("message", "El DesiredDate es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}else {
					
					List<PurchaseRequestProduct> purchaseRequestProducts = purchaseRequest.getPurchaseRequestProducts();
					
					purchaseRequestProducts = purchaseRequestProducts != null ? purchaseRequestProducts : new ArrayList<PurchaseRequestProduct>();
					
					purchaseRequest.setPurchaseRequestProducts(null);
					
					long idPurchaseRequestType = 1;
					
					purchaseRequest.setIdPurchaseRequestType(idPurchaseRequestType);
					
					purchaseRequest = purchaseRequestService.create(purchaseRequest);
					
					if(purchaseRequest != null && purchaseRequest.getId() != 0) {

						if(purchaseRequestProducts.size() > 0) {
							
							List<PurchaseRequestProduct> purchaseRequestProductsCreated = new ArrayList<PurchaseRequestProduct>();
							
							for (PurchaseRequestProduct purchaseRequestProduct : purchaseRequestProducts) {
								
								purchaseRequestProduct.setIdPurchaseRequest(purchaseRequest.getId());
								
								if(purchaseRequestProduct.getIdProduct() != null && purchaseRequestProduct.getWeight() != null && purchaseRequestProduct.getRequiresRefrigeration() != null) {
								
									PurchaseRequestProduct purchaseRequestProductExisting = purchaseRequestProductService.findByIdPurchaseRequestAndIdProduct(purchaseRequestProduct.getIdPurchaseRequest(), purchaseRequestProduct.getIdProduct());
									
									if(purchaseRequestProductExisting == null) {
										
										purchaseRequestProductExisting = new PurchaseRequestProduct();
										
										purchaseRequestProductExisting.setIdProduct(purchaseRequestProduct.getIdProduct());
										purchaseRequestProductExisting.setIdPurchaseRequest(purchaseRequestProduct.getIdPurchaseRequest());
										purchaseRequestProductExisting.setWeight(purchaseRequestProduct.getWeight());
										purchaseRequestProductExisting.setRequiresRefrigeration(purchaseRequestProduct.getRequiresRefrigeration());
										purchaseRequestProductExisting.setRemark(purchaseRequestProduct.getRemark());
										
										PurchaseRequestProduct purchaseRequestProductCreated = purchaseRequestProductService.create(purchaseRequestProductExisting);
										
										if(purchaseRequestProductCreated != null && purchaseRequestProductCreated.getId() != 0) {
											
											purchaseRequestProductsCreated.add(purchaseRequestProductCreated);
											
										}
									}
									
								}
								
							}
							
							for (PurchaseRequestProduct purchaseRequestProduct : purchaseRequestProducts) {
								
								List<PurchaseRequestProducer> purchaseRequestProducersProduct = purchaseRequestProducerService.findByIdPurchaseRequestProductAndIsParticipantEqualToOne(purchaseRequestProduct.getId());
								
								PurchaseRequestProduct purchaseRequestProductCreated = purchaseRequestProductsCreated.stream().filter(x -> x.getIdProduct() == purchaseRequestProduct.getIdProduct()).findFirst().get();
								
								for (PurchaseRequestProducer purchaseRequestProducer : purchaseRequestProducersProduct) {
									
									PurchaseRequestProducer purchaseRequestProducerNew = new PurchaseRequestProducer();
									
									purchaseRequestProducerNew.setExpirationDate(purchaseRequestProducer.getExpirationDate());
									purchaseRequestProducerNew.setIdProducer(purchaseRequestProducer.getIdProducer());
									purchaseRequestProducerNew.setIdPurchaseRequestProduct(purchaseRequestProductCreated.getId());
									purchaseRequestProducerNew.setPrice(purchaseRequestProducer.getPrice());
									purchaseRequestProducerNew.setWeight(purchaseRequestProductCreated.getWeight());
									
									purchaseRequestProducerService.create(purchaseRequestProducerNew);
								}
								
								purchaseRequestProductService.updateAgreedPriceById(purchaseRequestProductCreated.getId());
								
								PurchaseRequestProduct purchaseRequestProductExisting = purchaseRequestProductService.findById(purchaseRequestProduct.getId());
								
								if(purchaseRequestProductExisting != null) {
									
									double weight = purchaseRequestProductExisting.getWeight();
									
									weight = weight - purchaseRequestProductCreated.getWeight();
									
									purchaseRequestProductExisting.setWeight(weight);
									
									purchaseRequestProductService.updateById(purchaseRequestProductExisting);
									
								}
							}
							
							Double totalWeight = purchaseRequestProductsCreated.stream().mapToDouble(x -> x.getWeight()).sum();
							
							purchaseRequest.setTotalWeight(totalWeight);
							
							purchaseRequestService.updateById(purchaseRequest);
							purchaseRequestService.updateTotalPriceById(purchaseRequest.getId());
						}
						
						EventLog eventLog = new EventLog();
						
						eventLog.setIdEventType(1);
						eventLog.setIdUser(sessionToken.getIdUser());
						eventLog.setHost(httpServletRequest.getRemoteAddr());
						eventLog.setHttpMethod(httpServletRequest.getMethod());
						eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
						eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
						
						eventLogService.create(eventLog);
						
						map.put("message", "La solicitud de compra se registró con éxito.");
						map.put("statusCode", HttpStatus.CREATED.value());
					
						return ResponseEntity.ok().body(map);
						
					}else {
						
						map.put("message", "Hubo un problema al intentar registrar la solicitud de compra, Inténtalo de nuevo.");
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
	
	@ApiOperation(value = "Servicio para crear una nueva solicitud de compra")
	@PostMapping("create")
	public ResponseEntity<Map<String, Object>> create(@RequestHeader(name = "Authorization", required = true)String token, @RequestBody PurchaseRequest purchaseRequest, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User user = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && user != null && (user.getIdProfile() == 5 || user.getIdProfile() == 6) && user.getStatus() == 1) {
			
				if(purchaseRequest.getIdClient() == null) {
					
					map.put("message", "El IdClient es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}else if(purchaseRequest.getIdPurchaseRequestType() == null) {
					
					map.put("message", "El IdPurchaseRequestType es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}else if(purchaseRequest.getDesiredDate() == null) {
					
					map.put("message", "El DesiredDate es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}else {
					
					List<PurchaseRequestProduct> purchaseRequestProducts = purchaseRequest.getPurchaseRequestProducts();
					
					purchaseRequestProducts = purchaseRequestProducts != null ? purchaseRequestProducts : new ArrayList<PurchaseRequestProduct>();
					
					if(purchaseRequest.getIdPurchaseRequestType() == 2) {
						
						Contract contract = contractService.findByIdUserAndIsValidEqualToOne(user.getId());
						
						if(contract == null) {
							
							map.put("message", "El contrato para realizar una solicitud de compra hacia el extranjero no es válido.");
							map.put("statusCode", HttpStatus.NOT_FOUND.value());
						
							return ResponseEntity.ok().body(map);
							
						}else {
							
							purchaseRequest.setPurchaseRequestProducts(null);
							
							purchaseRequest = purchaseRequestService.create(purchaseRequest);
							
							if(purchaseRequest != null && purchaseRequest.getId() != 0) {
								
								if(purchaseRequestProducts.size() > 0) {
									
									for (PurchaseRequestProduct purchaseRequestProduct : purchaseRequestProducts) {
										
										purchaseRequestProduct.setIdPurchaseRequest(purchaseRequest.getId());
										
										if(purchaseRequestProduct.getIdProduct() != null && purchaseRequestProduct.getWeight() != null && purchaseRequestProduct.getRequiresRefrigeration() != null) {
										
											PurchaseRequestProduct purchaseRequestProductExisting = purchaseRequestProductService.findByIdPurchaseRequestAndIdProduct(purchaseRequestProduct.getIdPurchaseRequest(), purchaseRequestProduct.getIdProduct());
											
											if(purchaseRequestProductExisting == null) {
											
												purchaseRequestProductService.create(purchaseRequestProduct);
											}
										}
										
									}
									
									Double totalWeight = purchaseRequestProducts.stream().mapToDouble(x -> x.getWeight()).sum();
									
									purchaseRequest.setTotalWeight(totalWeight);
									
									purchaseRequestService.updateById(purchaseRequest);
								}
								
								EventLog eventLog = new EventLog();
								
								eventLog.setIdEventType(1);
								eventLog.setIdUser(sessionToken.getIdUser());
								eventLog.setHost(httpServletRequest.getRemoteAddr());
								eventLog.setHttpMethod(httpServletRequest.getMethod());
								eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
								eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
								
								eventLogService.create(eventLog);
								
								map.put("message", "La solicitud de compra se registró con éxito.");
								map.put("statusCode", HttpStatus.CREATED.value());
							
								return ResponseEntity.ok().body(map);
								
							}else {
								
								map.put("message", "Hubo un problema al intentar registrar la solicitud de compra, Inténtalo de nuevo.");
								map.put("statusCode", HttpStatus.NOT_FOUND.value());
							
								return ResponseEntity.ok().body(map);
								
							}
							
						}
						
					}else {
				
						purchaseRequest.setPurchaseRequestProducts(null);
						
						purchaseRequest = purchaseRequestService.create(purchaseRequest);
						
						if(purchaseRequest != null && purchaseRequest.getId() != 0) {

							if(purchaseRequestProducts.size() > 0) {
								
								for (PurchaseRequestProduct purchaseRequestProduct : purchaseRequestProducts) {
									
									purchaseRequestProduct.setIdPurchaseRequest(purchaseRequest.getId());
									
									if(purchaseRequestProduct.getIdProduct() != null && purchaseRequestProduct.getWeight() != null && purchaseRequestProduct.getRequiresRefrigeration() != null) {
									
										PurchaseRequestProduct purchaseRequestProductExisting = purchaseRequestProductService.findByIdPurchaseRequestAndIdProduct(purchaseRequestProduct.getIdPurchaseRequest(), purchaseRequestProduct.getIdProduct());
										
										if(purchaseRequestProductExisting == null) {
										
											purchaseRequestProductService.create(purchaseRequestProduct);
										}
										
									}
									
								}
								
								Double totalWeight = purchaseRequestProducts.stream().mapToDouble(x -> x.getWeight()).sum();
								
								purchaseRequest.setTotalWeight(totalWeight);
								
								purchaseRequestService.updateById(purchaseRequest);
							}
							
							EventLog eventLog = new EventLog();
							
							eventLog.setIdEventType(1);
							eventLog.setIdUser(sessionToken.getIdUser());
							eventLog.setHost(httpServletRequest.getRemoteAddr());
							eventLog.setHttpMethod(httpServletRequest.getMethod());
							eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
							eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
							
							eventLogService.create(eventLog);
							
							map.put("message", "La solicitud de compra se registró con éxito.");
							map.put("statusCode", HttpStatus.CREATED.value());
						
							return ResponseEntity.ok().body(map);
							
						}else {
							
							map.put("message", "Hubo un problema al intentar registrar la solicitud de compra, Inténtalo de nuevo.");
							map.put("statusCode", HttpStatus.NOT_FOUND.value());
						
							return ResponseEntity.ok().body(map);
							
						}
						
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
	
	@ApiOperation(value = "Servicio para actualizar una solicitud de compra existente por Id")
	@PutMapping("updateStatusById/{id}")
	public ResponseEntity<Map<String, Object>> updateStatusById(@RequestHeader(name = "Authorization", required = true)String token, @PathVariable("id") long id, @RequestBody PurchaseRequest purchaseRequest, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User user = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && user != null && (user.getIdProfile() == 1 || user.getIdProfile() == 4 || user.getIdProfile() == 5 || user.getIdProfile() == 6) && user.getStatus() == 1) {
			
				if(purchaseRequest.getId() == null) {
					
					map.put("message", "El Id es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}
				else if(purchaseRequest.getIdPurchaseRequestStatus() == null) {
					
					map.put("message", "El IdPurchaseRequestStatus es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}else {
					
					PurchaseRequest purchaseRequestExisting = purchaseRequestService.findById(id);
					
					if(purchaseRequestExisting != null) {
					
						PurchaseRequest purchaseRequestUpdated = purchaseRequestService.updateStatusById(purchaseRequest);
						
						if(purchaseRequestUpdated != null) {
							
							EventLog eventLog = new EventLog();
							
							eventLog.setIdEventType(1);
							eventLog.setIdUser(sessionToken.getIdUser());
							eventLog.setHost(httpServletRequest.getRemoteAddr());
							eventLog.setHttpMethod(httpServletRequest.getMethod());
							eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
							eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
							
							eventLogService.create(eventLog);
							
							map.put("message", "La solicitud de compra se actualizo con éxito.");
							map.put("statusCode", HttpStatus.OK.value());
						
							return ResponseEntity.ok().body(map);
							
						}else {
							
							map.put("message", "Hubo un problema al intentar actualizar la solicitud de compra, Inténtalo de nuevo.");
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
	
	@ApiOperation(value = "Servicio para actualizar la propiedad IsPublic de una solicitud de compra existente por Id")
	@PutMapping("updateIsPublicById/{id}")
	public ResponseEntity<Map<String, Object>> updateIsPublicById(@RequestHeader(name = "Authorization", required = true)String token, @PathVariable("id") long id, @RequestBody PurchaseRequest purchaseRequest, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User user = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && user != null && user.getIdProfile() == 1 && user.getStatus() == 1) {
			
				if(purchaseRequest.getId() == null) {
					
					map.put("message", "El Id es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}
				else if(purchaseRequest.getIsPublic() == null) {
					
					map.put("message", "El IsPublic es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}else {
					
					PurchaseRequest purchaseRequestExisting = purchaseRequestService.findById(id);
					
					if(purchaseRequestExisting != null) {
					
						PurchaseRequest purchaseRequestUpdated = purchaseRequestService.updateIsPublicById(purchaseRequest);
						
						if(purchaseRequestUpdated != null) {
							
							EventLog eventLog = new EventLog();
							
							eventLog.setIdEventType(1);
							eventLog.setIdUser(sessionToken.getIdUser());
							eventLog.setHost(httpServletRequest.getRemoteAddr());
							eventLog.setHttpMethod(httpServletRequest.getMethod());
							eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
							eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
							
							eventLogService.create(eventLog);
							
							map.put("message", "La solicitud de compra se actualizo con éxito.");
							map.put("statusCode", HttpStatus.OK.value());
						
							return ResponseEntity.ok().body(map);
							
						}else {
							
							map.put("message", "Hubo un problema al intentar actualizar la solicitud de compra, Inténtalo de nuevo.");
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
	
	@ApiOperation(value = "Servicio para actualizar la propiedad TotalPrice de una solicitud de compra existente")
	@PutMapping("updateTotalPriceById/{id}")
	public ResponseEntity<Map<String, Object>> updateTotalPriceById(@RequestHeader(name = "Authorization", required = true)String token, @PathVariable("id") long id, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User user = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && user != null && user.getIdProfile() == 1 && user.getStatus() == 1) {
			
				PurchaseRequest purchaseRequestExisting = purchaseRequestService.findById(id);
				
				if(purchaseRequestExisting != null) {
				
					PurchaseRequest purchaseRequestUpdated = purchaseRequestService.updateTotalPriceById(id);
					
					if(purchaseRequestUpdated != null) {
						
						EventLog eventLog = new EventLog();
						
						eventLog.setIdEventType(1);
						eventLog.setIdUser(sessionToken.getIdUser());
						eventLog.setHost(httpServletRequest.getRemoteAddr());
						eventLog.setHttpMethod(httpServletRequest.getMethod());
						eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
						eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
						
						eventLogService.create(eventLog);
						
						map.put("message", "La solicitud de compra se actualizo con éxito.");
						map.put("statusCode", HttpStatus.OK.value());
					
						return ResponseEntity.ok().body(map);
						
					}else {
						
						map.put("message", "Hubo un problema al intentar actualizar la solicitud de compra, Inténtalo de nuevo.");
						map.put("statusCode", HttpStatus.NOT_FOUND.value());
					
						return ResponseEntity.ok().body(map);
						
					}
					
				}else {

					map.put("message", "La solicitud de compra no existe.");
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
