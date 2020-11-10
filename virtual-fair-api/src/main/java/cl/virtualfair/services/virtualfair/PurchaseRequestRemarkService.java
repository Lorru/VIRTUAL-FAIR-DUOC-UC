package cl.virtualfair.services.virtualfair;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import cl.virtualfair.models.virtualfair.PurchaseRequestRemark;
import cl.virtualfair.repositories.IPurchaseRequestRemarkRepository;

@Service
public class PurchaseRequestRemarkService {

	@Autowired
	private IPurchaseRequestRemarkRepository iPurchaseRequestRemarkRepository;
	
	public PurchaseRequestRemarkService() {
		
	}
	
	public PurchaseRequestRemark create(PurchaseRequestRemark purchaseRequestRemark) {
		
		purchaseRequestRemark = iPurchaseRequestRemarkRepository.save(purchaseRequestRemark);
		
		return purchaseRequestRemark;
	}
	
	public PurchaseRequestRemark findByIdPurchaseRequestStatusAndIdPurchaseRequest(long idPurchaseRequestStatus, long idPurchaseRequest) {
		
		PurchaseRequestRemark purchaseRequestRemark = iPurchaseRequestRemarkRepository.findByIdPurchaseRequestStatusAndIdPurchaseRequest(idPurchaseRequestStatus, idPurchaseRequest);
		
		return purchaseRequestRemark;
	}
}
