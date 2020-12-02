package cl.virtualfair.services.virtualfair;

import java.lang.reflect.Field;
import java.time.LocalDateTime;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import cl.virtualfair.models.virtualfair.PurchaseRequest;
import cl.virtualfair.models.virtualfair.PurchaseRequestProduct;
import cl.virtualfair.models.virtualfair.TransportAuctionCarrier;
import cl.virtualfair.repositories.IPurchaseRequestRepository;

@Service
public class PurchaseRequestService {

	@Autowired
	private IPurchaseRequestRepository iPurchaseRequestRepository;
	
	@Autowired 
	private PurchaseRequestProductService purchaseRequestProductService;
	
	@Autowired
	private TransportAuctionCarrierService transportAuctionCarrierService;
	
	public PurchaseRequestService() {
		
	}

	public List<PurchaseRequest> findAll(){
		
		List<PurchaseRequest> purchaseRequests = iPurchaseRequestRepository.findAll();
		
		return purchaseRequests;
	}
	
	public List<PurchaseRequest> findByIsPublicEqualToZero(){
		
		List<PurchaseRequest> purchaseRequests = iPurchaseRequestRepository.findByIsPublicEqualToZero();
		
		return purchaseRequests;
	}
	
	public List<PurchaseRequest> findByIsPublicEqualToOne(){
		
		List<PurchaseRequest> purchaseRequests = iPurchaseRequestRepository.findByIsPublicEqualToOne();
		
		return purchaseRequests;
	}
	
	public List<PurchaseRequest> findByIdPurchaseRequestStatusAndIdPurchaseRequestType(long idPurchaseRequestStatus, long idPurchaseRequestType){
		
		List<PurchaseRequest> purchaseRequests = iPurchaseRequestRepository.findByIdPurchaseRequestStatusAndIdPurchaseRequestType(idPurchaseRequestStatus, idPurchaseRequestType);
		
		return purchaseRequests;
	}
	
	public List<PurchaseRequest> findByIdPurchaseRequestTypeAndIsPublicEqualToOne(long idPurchaseRequestType){
		
		List<PurchaseRequest> purchaseRequests = iPurchaseRequestRepository.findByIdPurchaseRequestTypeAndIsPublicEqualToOne(idPurchaseRequestType);
		
		return purchaseRequests;
	}
	
	public List<PurchaseRequest> findByIdPurchaseRequestTypeAndIdProducerAndIsPublicEqualToOne(long idPurchaseRequestType, long idProducer){
		
		List<PurchaseRequest> purchaseRequests = iPurchaseRequestRepository.findByIdPurchaseRequestTypeAndIdProducerAndIsPublicEqualToOne(idPurchaseRequestType, idProducer);
		
		return purchaseRequests;
	}
	
	public List<PurchaseRequest> findByIdClient(long idClient){
		
		List<PurchaseRequest> purchaseRequests = iPurchaseRequestRepository.findByIdClient(idClient);
		
		return purchaseRequests;
	}
	
	public PurchaseRequest findById(long id) {
		
		PurchaseRequest purchaseRequest = iPurchaseRequestRepository.findById(id);
		
		return purchaseRequest;
		
	}
	
	public PurchaseRequest create(PurchaseRequest purchaseRequest) {
		
		long idPurchaseRequestStatus = 1;
		
		purchaseRequest.setIdPurchaseRequestStatus(idPurchaseRequestStatus);
		purchaseRequest.setIsPublic(0);
		purchaseRequest.setCreationDate(LocalDateTime.now());
		purchaseRequest.setUpdateDate(LocalDateTime.now());
		
		purchaseRequest = iPurchaseRequestRepository.save(purchaseRequest);
		
		return purchaseRequest;
		
	}
	
	public PurchaseRequest updateById(PurchaseRequest purchaseRequest) throws IllegalArgumentException, IllegalAccessException, NoSuchFieldException, SecurityException {
		
		long id = purchaseRequest.getId();
		
		PurchaseRequest purchaseRequestExisting = iPurchaseRequestRepository.findById(id);
		
		List<Field> fields = Arrays.stream(purchaseRequestExisting.getClass().getDeclaredFields()).filter(x -> 
								x.getName() != "serialVersionUID" && 
								x.getName() != "Id" && 
								x.getName() != "IdPurchaseRequestType" && 
								x.getName() != "IdPurchaseRequestStatus" &&
								x.getName() != "IdClient" &&
								x.getName() != "DesiredDate" &&
								x.getName() != "CreationDate" &&
								x.getName() != "IsPublic"
								).collect(Collectors.toList());

		for (Field field : fields) {
			
			Field fieldObject = purchaseRequest.getClass().getDeclaredField(field.getName());
			
			fieldObject.setAccessible(true);
			field.setAccessible(true);
			
			field.set(purchaseRequestExisting, fieldObject.get(purchaseRequest));
		}
		
		purchaseRequestExisting.setUpdateDate(LocalDateTime.now());

		purchaseRequestExisting = iPurchaseRequestRepository.save(purchaseRequestExisting);
		
		return purchaseRequestExisting;
		
	}
	
	public PurchaseRequest updateStatusById(PurchaseRequest purchaseRequest) {
		
		long id = purchaseRequest.getId();
		
		PurchaseRequest purchaseRequestExisting = iPurchaseRequestRepository.findById(id);
		
		purchaseRequestExisting.setUpdateDate(LocalDateTime.now());
		purchaseRequestExisting.setIdPurchaseRequestStatus(purchaseRequest.getIdPurchaseRequestStatus());

		purchaseRequestExisting = iPurchaseRequestRepository.save(purchaseRequestExisting);
		
		return purchaseRequestExisting;
		
	}
	
	public PurchaseRequest updateIsPublicById(PurchaseRequest purchaseRequest) {
		
		long id = purchaseRequest.getId();
		
		PurchaseRequest purchaseRequestExisting = iPurchaseRequestRepository.findById(id);
		
		purchaseRequestExisting.setUpdateDate(LocalDateTime.now());
		purchaseRequestExisting.setIsPublic(purchaseRequest.getIsPublic());
		
		purchaseRequestExisting = iPurchaseRequestRepository.save(purchaseRequestExisting);
		
		return purchaseRequestExisting;
		
	}
	
	public PurchaseRequest updateTotalPriceById(long id) {
		
		PurchaseRequest purchaseRequest = iPurchaseRequestRepository.findById(id);
		
		long totalPrice = 0;
		
		List<PurchaseRequestProduct> purchaseRequestProducts = purchaseRequestProductService.findByIdPurchaseRequest(id);
		
		TransportAuctionCarrier transportAuctionCarrier = transportAuctionCarrierService.findByIdPurchaseRequestAndIsParticipantEqualToOne(id);
		
		totalPrice = purchaseRequestProducts.stream().mapToLong(x -> x.getAgreedPrice()).sum();
		
		if(transportAuctionCarrier != null) {
			
			totalPrice = totalPrice + transportAuctionCarrier.getPrice();
			
		}
		
		totalPrice = (long)(totalPrice * 1.16);
		
		purchaseRequest.setUpdateDate(LocalDateTime.now());
		
		purchaseRequest.setTotalPrice(totalPrice);

		purchaseRequest = iPurchaseRequestRepository.save(purchaseRequest);
		
		return purchaseRequest;
		
	}
}
