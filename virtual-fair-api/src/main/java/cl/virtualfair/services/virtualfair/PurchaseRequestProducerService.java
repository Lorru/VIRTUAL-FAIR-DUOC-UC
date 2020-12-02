package cl.virtualfair.services.virtualfair;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import cl.virtualfair.models.virtualfair.PurchaseRequestProducer;
import cl.virtualfair.models.virtualfair.PurchaseRequestProduct;
import cl.virtualfair.repositories.IPurchaseRequestProducerRepository;

@Service
public class PurchaseRequestProducerService {

	@Autowired
	private IPurchaseRequestProducerRepository iPurchaseRequestProducerRepository;
	
	@Autowired
	private PurchaseRequestProductService purchaseRequestProductService;
	
	public PurchaseRequestProducerService() {
		
	}
	
	public List<PurchaseRequestProducer> findByIdPurchaseRequest(long idPurchaseRequest){
		
		List<PurchaseRequestProducer> purchaseRequestProducers = iPurchaseRequestProducerRepository.findByIdPurchaseRequest(idPurchaseRequest);
		
		return purchaseRequestProducers;
		
	}
	
	public List<PurchaseRequestProducer> findByIdPurchaseRequestAndIdProducer(long idPurchaseRequest, long idProducer){
		
		List<PurchaseRequestProducer> purchaseRequestProducers = iPurchaseRequestProducerRepository.findByIdPurchaseRequestAndIdProducer(idPurchaseRequest, idProducer);
		
		return purchaseRequestProducers;
		
	}
	
	public List<PurchaseRequestProducer> findByIdPurchaseRequestAndIdProducerAndIsParticipantEqualToOne(long idPurchaseRequest, long idProducer){
		
		List<PurchaseRequestProducer> purchaseRequestProducers = iPurchaseRequestProducerRepository.findByIdPurchaseRequestAndIdProducerAndIsParticipantEqualToOne(idPurchaseRequest, idProducer);
		
		return purchaseRequestProducers;
		
	}

	public List<PurchaseRequestProducer> findByIdPurchaseRequestProductAndIsParticipantEqualToOne(long idPurchaseRequestProduct){
		
		List<PurchaseRequestProducer> purchaseRequestProducers = iPurchaseRequestProducerRepository.findByIdPurchaseRequestProductAndIsParticipantEqualToOne(idPurchaseRequestProduct);
		
		return purchaseRequestProducers;
		
	}
	
	public List<PurchaseRequestProducer> findByIdPurchaseRequestAndIsParticipantEqualToOne(long idPurchaseRequest){
		
		List<PurchaseRequestProducer> purchaseRequestProducers = iPurchaseRequestProducerRepository.findByIdPurchaseRequestAndIsParticipantEqualToOne(idPurchaseRequest);
		
		return purchaseRequestProducers;
		
	}
	
	public List<PurchaseRequestProducer> getParticipantsByIdPurchaseRequest(long idPurchaseRequest){
		
		List<PurchaseRequestProducer> purchaseRequestProducers = iPurchaseRequestProducerRepository.findByIdPurchaseRequest(idPurchaseRequest);
	
		List<PurchaseRequestProduct> purchaseRequestProducts = purchaseRequestProductService.findByIdPurchaseRequest(idPurchaseRequest);
		
		List<PurchaseRequestProducer> purchaseRequestProducersParticipant = new ArrayList<PurchaseRequestProducer>();
		
		for (PurchaseRequestProduct purchaseRequestProduct : purchaseRequestProducts) {
			
			List<PurchaseRequestProducer> purchaseRequestProducersProduct = purchaseRequestProducers.stream().filter(x -> x.getIdPurchaseRequestProduct() == purchaseRequestProduct.getId() && x.getWeight() <= purchaseRequestProduct.getWeight()).collect(Collectors.toList());
			
			if(purchaseRequestProducersProduct.size() > 0) {
			
				double averagePrice = purchaseRequestProducersProduct.stream().mapToLong(x -> x.getPrice()).average().getAsDouble();
				
				for (PurchaseRequestProducer purchaseRequestProducer : purchaseRequestProducersProduct) {
					
					if(purchaseRequestProducer.getPrice() <= averagePrice) {
				
						purchaseRequestProducersParticipant.add(purchaseRequestProducer);
						
					}
					
				}
				
			}
			
		}
		
		for (PurchaseRequestProducer purchaseRequestProducer : purchaseRequestProducers) {
						
			if(purchaseRequestProducersParticipant.stream().filter(x -> x.getId() == purchaseRequestProducer.getId()).count() > 0) {
				
				purchaseRequestProducer.setIsParticipant(1);
				
			}else {
				
				purchaseRequestProducer.setIsParticipant(0);
				
			}
			
			iPurchaseRequestProducerRepository.save(purchaseRequestProducer);
			
		}
		
		for (PurchaseRequestProduct purchaseRequestProduct: purchaseRequestProducts) {
		
			purchaseRequestProductService.updateAgreedPriceById(purchaseRequestProduct.getId());
			
		}
		
		return purchaseRequestProducersParticipant;
		
	}
	
	public PurchaseRequestProducer findByIdPurchaseRequestProductAndIdProducer(long idPurchaseRequestProduct, long idProducer) {
		
		PurchaseRequestProducer purchaseRequestProducer = iPurchaseRequestProducerRepository.findByIdPurchaseRequestProductAndIdProducer(idPurchaseRequestProduct, idProducer);
		
		return purchaseRequestProducer;
		
	}
	
	public PurchaseRequestProducer findById(long id) {
		
		PurchaseRequestProducer purchaseRequestProducer = iPurchaseRequestProducerRepository.findById(id);
		
		return purchaseRequestProducer;
		
	}
	
	public PurchaseRequestProducer create(PurchaseRequestProducer purchaseRequestProducer) {
		
		purchaseRequestProducer.setIsParticipant(0);
		
		purchaseRequestProducer = iPurchaseRequestProducerRepository.save(purchaseRequestProducer);
		
		return purchaseRequestProducer;
		
	}
	
	public PurchaseRequestProducer destroyById(long id) {
		
		PurchaseRequestProducer purchaseRequestProducer = iPurchaseRequestProducerRepository.findById(id);
		
		iPurchaseRequestProducerRepository.delete(purchaseRequestProducer);
		
		purchaseRequestProducer = findById(id);
		
		return purchaseRequestProducer;
		
	}
}
