package cl.virtualfair.services.virtualfair;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import cl.virtualfair.models.virtualfair.PurchaseRequestProducer;
import cl.virtualfair.models.virtualfair.PurchaseRequestProduct;
import cl.virtualfair.repositories.IPurchaseRequestProductRepository;

@Service
public class PurchaseRequestProductService {

	@Autowired
	private IPurchaseRequestProductRepository iPurchaseRequestProductRepository;
	
	@Autowired
	private PurchaseRequestProducerService purchaseRequestProducerService;
	
	public PurchaseRequestProductService() {
		
	}
	
	public List<PurchaseRequestProduct> findByIdPurchaseRequest(long idPurchaseRequest){
		
		List<PurchaseRequestProduct> purchaseRequestProducts = iPurchaseRequestProductRepository.findByIdPurchaseRequest(idPurchaseRequest);
		
		return purchaseRequestProducts;
	}
	
	public PurchaseRequestProduct findByIdPurchaseRequestAndIdProduct(long idPurchaseRequest, long idProduct){
		
		PurchaseRequestProduct purchaseRequestProduct = iPurchaseRequestProductRepository.findByIdPurchaseRequestAndIdProduct(idPurchaseRequest, idProduct);
		
		return purchaseRequestProduct;
	}
	
	public PurchaseRequestProduct create(PurchaseRequestProduct purchaseRequestProduct) {
		
		purchaseRequestProduct = iPurchaseRequestProductRepository.save(purchaseRequestProduct);
		
		return purchaseRequestProduct;
		
	}

	public PurchaseRequestProduct findById(long id) {
		
		PurchaseRequestProduct purchaseRequestProduct = iPurchaseRequestProductRepository.findById(id);
		
		return purchaseRequestProduct;
	}
	
	public PurchaseRequestProduct updateAgreedPriceById(long id) {
		
		PurchaseRequestProduct purchaseRequestProduct = findById(id);
		
		PurchaseRequestProducer purchaseRequestProducer = purchaseRequestProducerService.findByIdPurchaseRequestProductAndIsParticipantEqualToOne(purchaseRequestProduct.getId());
		
		if(purchaseRequestProducer != null) {
			
			purchaseRequestProduct.setAgreedPrice(purchaseRequestProducer.getPrice());
			
			purchaseRequestProduct = iPurchaseRequestProductRepository.save(purchaseRequestProduct);
			
		}
		
		return purchaseRequestProduct;
		
	}
}
