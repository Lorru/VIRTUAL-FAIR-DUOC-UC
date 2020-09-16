package cl.virtualfair.services.virtualfair;

import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import cl.virtualfair.models.virtualfair.PurchaseRequest;
import cl.virtualfair.repositories.IPurchaseRequestRepository;

@Service
public class PurchaseRequestService {

	@Autowired
	private IPurchaseRequestRepository iPurchaseRequestRepository;
	
	public PurchaseRequestService() {
		
	}
	
	public List<PurchaseRequest> findAll(String searcher){
		
		List<PurchaseRequest> purchaseRequests = new ArrayList<PurchaseRequest>();
		
		purchaseRequests = iPurchaseRequestRepository.findAll();
		
		return purchaseRequests;
	}
	
	public List<PurchaseRequest> findByIdPurchaseRequestType(long idPurchaseRequestType){
		
		List<PurchaseRequest> purchaseRequests = iPurchaseRequestRepository.findByIdPurchaseRequestType(idPurchaseRequestType);
		
		return purchaseRequests;
	}
	
	public List<PurchaseRequest> findByIdClient(long idClient, String searcher){
		
		List<PurchaseRequest> purchaseRequests = new ArrayList<PurchaseRequest>();
		
		purchaseRequests = iPurchaseRequestRepository.findByIdClient(idClient);
		
		return purchaseRequests;
	}
}
