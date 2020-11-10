package cl.virtualfair.services.virtualfair;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import cl.virtualfair.models.virtualfair.PurchaseRequestProducer;
import cl.virtualfair.repositories.IPurchaseRequestProducerRepository;

@Service
public class PurchaseRequestProducerService {

	@Autowired
	private IPurchaseRequestProducerRepository iPurchaseRequestProducerRepository;
	
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

	public List<PurchaseRequestProducer> getParticipantsByIdPurchaseRequest(long idPurchaseRequest){
		
		List<PurchaseRequestProducer> purchaseRequestProducers = iPurchaseRequestProducerRepository.findByIdPurchaseRequest(idPurchaseRequest);
		
		
		
		List<PurchaseRequestProducer> purchaseRequestProducersParticipant = purchaseRequestProducers.stream().filter(x -> x.getIsParticipant() == 1).collect(Collectors.toList());
		
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
		
		purchaseRequestProducer = iPurchaseRequestProducerRepository.save(purchaseRequestProducer);
		
		return purchaseRequestProducer;
		
	}

	public PurchaseRequestProducer findByIdPurchaseRequestProductAndIsParticipantEqualToOne(long idPurchaseRequestProduct){
		
		PurchaseRequestProducer purchaseRequestProducer = iPurchaseRequestProducerRepository.findByIdPurchaseRequestProductAndIsParticipantEqualToOne(idPurchaseRequestProduct);
		
		return purchaseRequestProducer;
		
	}
	
	public PurchaseRequestProducer destroyById(long id) {
		
		PurchaseRequestProducer purchaseRequestProducer = iPurchaseRequestProducerRepository.findById(id);
		
		iPurchaseRequestProducerRepository.delete(purchaseRequestProducer);
		
		purchaseRequestProducer = findById(id);
		
		return purchaseRequestProducer;
		
	}
}
