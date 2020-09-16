package cl.virtualfair.services.virtualfair;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import cl.virtualfair.models.virtualfair.PurchaseRequestStatus;
import cl.virtualfair.repositories.IPurchaseRequestStatusRepository;

@Service
public class PurchaseRequestStatusService {

	@Autowired
	private IPurchaseRequestStatusRepository iPurchaseRequestStatusRepository;
	
	public PurchaseRequestStatusService() {
		
	}
	
	public List<PurchaseRequestStatus> findAll(){
		
		List<PurchaseRequestStatus> purchaseRequestStatus = iPurchaseRequestStatusRepository.findAll();
		
		return purchaseRequestStatus;
		
	}
}
