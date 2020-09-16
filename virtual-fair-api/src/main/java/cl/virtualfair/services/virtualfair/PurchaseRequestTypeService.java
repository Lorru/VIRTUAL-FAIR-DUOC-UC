package cl.virtualfair.services.virtualfair;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import cl.virtualfair.models.virtualfair.PurchaseRequestType;
import cl.virtualfair.repositories.IPurchaseRequestTypeRepository;

@Service
public class PurchaseRequestTypeService {

	@Autowired
	private IPurchaseRequestTypeRepository iPurchaseRequestTypeRepository;
	
	public PurchaseRequestTypeService() {
		
	}
	
	public List<PurchaseRequestType> findAll(){
		
		List<PurchaseRequestType> purchaseRequestTypes = iPurchaseRequestTypeRepository.findAll();
		
		return purchaseRequestTypes;
		
	}
}
