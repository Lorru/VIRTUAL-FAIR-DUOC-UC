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
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestHeader;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import cl.virtualfair.models.virtualfair.Contract;
import cl.virtualfair.models.virtualfair.EventLog;
import cl.virtualfair.models.virtualfair.PurchaseRequest;
import cl.virtualfair.models.virtualfair.SessionToken;
import cl.virtualfair.models.virtualfair.TransportAuction;
import cl.virtualfair.models.virtualfair.TransportAuctionCarrier;
import cl.virtualfair.models.virtualfair.User;
import cl.virtualfair.services.virtualfair.ContractService;
import cl.virtualfair.services.virtualfair.EventLogService;
import cl.virtualfair.services.virtualfair.PurchaseRequestService;
import cl.virtualfair.services.virtualfair.SessionTokenService;
import cl.virtualfair.services.virtualfair.TransportAuctionCarrierService;
import cl.virtualfair.services.virtualfair.TransportAuctionService;
import cl.virtualfair.services.virtualfair.UserService;

@RestController
@RequestMapping("/api/TransportAuctionCarrier/")
@CrossOrigin
public class TransportAuctionCarrierController {

	@Autowired
	private UserService userService;
	
	@Autowired
	private TransportAuctionCarrierService transportAuctionCarrierService;
	
	@Autowired
	private TransportAuctionService transportAcutionService;
	
	@Autowired
	private PurchaseRequestService purchaseRequestService;
	
	@Autowired
	private ContractService contractService;
	
	@Autowired
	private SessionTokenService sessionTokenService;
	
	@Autowired
	private EventLogService eventLogService;
	
	@GetMapping("findByIdTransportAuction/{idTransportAuction}")
	public ResponseEntity<Map<String, Object>> findByIdTransportAuction(@RequestHeader(name = "Authorization", required = true)String token, @PathVariable("idTransportAuction") long idTransportAuction, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User user = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && user != null && user.getIdProfile() == 4 && user.getStatus() == 1) {
			
				List<TransportAuctionCarrier> transportAuctionCarriers = transportAuctionCarrierService.findByIdTransportAuction(idTransportAuction);
				
				if(transportAuctionCarriers.size() > 0) {

					EventLog eventLog = new EventLog();
					
					eventLog.setIdEventType(1);
					eventLog.setIdUser(sessionToken.getIdUser());
					eventLog.setHost(httpServletRequest.getRemoteAddr());
					eventLog.setHttpMethod(httpServletRequest.getMethod());
					eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
					eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
					
					eventLogService.create(eventLog);
					
					map.put("transportAuctionCarriers", transportAuctionCarriers);
					map.put("countRows", transportAuctionCarriers.size());
					map.put("statusCode", HttpStatus.OK.value());
					
					return ResponseEntity.ok().body(map);
					
				}else {

					map.put("transportAuctionCarriers", transportAuctionCarriers);
					map.put("countRows", transportAuctionCarriers.size());
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
	
	@GetMapping("getParticipantByIdPurchaseRequest/{idPurchaseRequest}")
	public ResponseEntity<Map<String, Object>> getParticipantByIdPurchaseRequest(@RequestHeader(name = "Authorization", required = true)String token, @PathVariable("idPurchaseRequest") long idPurchaseRequest, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User user = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && user != null && user.getIdProfile() == 1 && user.getStatus() == 1) {
			
				TransportAuctionCarrier transportAuctionCarrier = transportAuctionCarrierService.getParticipantByIdPurchaseRequest(idPurchaseRequest);
				
				if(transportAuctionCarrier != null) {

					EventLog eventLog = new EventLog();
					
					eventLog.setIdEventType(1);
					eventLog.setIdUser(sessionToken.getIdUser());
					eventLog.setHost(httpServletRequest.getRemoteAddr());
					eventLog.setHttpMethod(httpServletRequest.getMethod());
					eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
					eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
					
					eventLogService.create(eventLog);
					
					map.put("transportAuctionCarrier", transportAuctionCarrier);
					map.put("statusCode", HttpStatus.OK.value());
					
					return ResponseEntity.ok().body(map);
					
				}else {

					map.put("message", "No existe ningún participante para esta solicitud de compra.");
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
	
	@PostMapping("create")
	public ResponseEntity<Map<String, Object>> create(@RequestHeader(name = "Authorization", required = true)String token, @RequestBody TransportAuctionCarrier transportAuctionCarrier, HttpServletRequest httpServletRequest){
		
		Map<String, Object> map = new HashMap<String, Object>();
		
		try {
			
			String host = httpServletRequest.getRemoteAddr();
			
			SessionToken sessionToken = sessionTokenService.findByTokenAndHost(token, host);
			
			User user = sessionToken != null ? userService.findById(sessionToken.getIdUser()) : null;
			
			if(sessionToken != null && user != null && user.getIdProfile() == 4 && user.getStatus() == 1) {
			
				if(transportAuctionCarrier.getIdTransportAuction() == null) {
					
					map.put("message", "El IdTransportAuction es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}else if(transportAuctionCarrier.getIdCarrier() == null) {
					
					map.put("message", "El IdCarrier es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}else if(transportAuctionCarrier.getPrice() == null) {
					
					map.put("message", "El Price es obligatorio.");
					map.put("statusCode", HttpStatus.NO_CONTENT.value());
				
					return ResponseEntity.ok().body(map);
					
				}else {

					TransportAuctionCarrier transportAuctionCarrierExisting = transportAuctionCarrierService.findByIdTransportAuctionAndIdCarrier(transportAuctionCarrier.getIdTransportAuction(), transportAuctionCarrier.getIdCarrier());
					
					if(transportAuctionCarrierExisting == null) {
						
						TransportAuction transportAuction = transportAcutionService.findById(transportAuctionCarrier.getIdTransportAuction());
						
						if(transportAuction != null) {
							
							PurchaseRequest purchaseRequest = purchaseRequestService.findById(transportAuction.getIdPurchaseRequest());
							
							if(purchaseRequest != null) {
								
								if(purchaseRequest.getIdPurchaseRequestType() == 2) {
									
									Contract contract = contractService.findByIdUser(user.getId());
									
									if(contract != null) {
										
										if(contract.getIsValid() == 1) {
											
											transportAuctionCarrier = transportAuctionCarrierService.create(transportAuctionCarrier);
											
											if(transportAuctionCarrier != null && transportAuctionCarrier.getId() != 0) {
											
												EventLog eventLog = new EventLog();
												
												eventLog.setIdEventType(1);
												eventLog.setIdUser(sessionToken.getIdUser());
												eventLog.setHost(httpServletRequest.getRemoteAddr());
												eventLog.setHttpMethod(httpServletRequest.getMethod());
												eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
												eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
												
												eventLogService.create(eventLog);
												
												map.put("message", "Tu oferta se registró con éxito, Ya estás participando.");
												map.put("statusCode", HttpStatus.CREATED.value());
											
												return ResponseEntity.ok().body(map);

												
											}else {
												
												map.put("message", "Hubo un problema al intentar registrar la oferta, Inténtalo de nuevo.");
												map.put("statusCode", HttpStatus.NOT_FOUND.value());
											
												return ResponseEntity.ok().body(map);
												
											}
											
										}else {
											
											map.put("message", "El contrato para poder realizar una oferta de una solicitud de compra hacia el extranjero no es válido.");
											map.put("statusCode", HttpStatus.NOT_FOUND.value());
										
											return ResponseEntity.ok().body(map);
											
										}
										
									}else {
										
										map.put("message", "El contrato para poder realizar una oferta de una solicitud de compra hacia el extranjero no es válido.");
										map.put("statusCode", HttpStatus.NOT_FOUND.value());
									
										return ResponseEntity.ok().body(map);
										
									}
									
								}else {

									transportAuctionCarrier = transportAuctionCarrierService.create(transportAuctionCarrier);
									
									if(transportAuctionCarrier != null && transportAuctionCarrier.getId() != 0) {
									
										EventLog eventLog = new EventLog();
										
										eventLog.setIdEventType(1);
										eventLog.setIdUser(sessionToken.getIdUser());
										eventLog.setHost(httpServletRequest.getRemoteAddr());
										eventLog.setHttpMethod(httpServletRequest.getMethod());
										eventLog.setController(httpServletRequest.getRequestURI().split("/")[2]);
										eventLog.setMethod(httpServletRequest.getRequestURI().split("/")[3]);
										
										eventLogService.create(eventLog);
										
										map.put("message", "Tu oferta se registró con éxito, Ya estás participando.");
										map.put("statusCode", HttpStatus.CREATED.value());
									
										return ResponseEntity.ok().body(map);

										
									}else {
										
										map.put("message", "Hubo un problema al intentar registrar la oferta, Inténtalo de nuevo.");
										map.put("statusCode", HttpStatus.NOT_FOUND.value());
									
										return ResponseEntity.ok().body(map);
										
									}
									
								}
								
							}else {
							
								map.put("message", "La solicitud de compra no existe.");
								map.put("statusCode", HttpStatus.NOT_FOUND.value());
							
								return ResponseEntity.ok().body(map);
								
							}
							
						}else {
						
							map.put("message", "La subasta no existe.");
							map.put("statusCode", HttpStatus.NOT_FOUND.value());
						
							return ResponseEntity.ok().body(map);
							
						}
						
					}else {
						
						map.put("message", "La oferta ya existe para esta subasta.");
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
