package cl.virtualfair.services.virtualfair;

import java.lang.reflect.Field;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

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
	
	@Autowired
	private PurchaseRequestService purchaseRequestService;
	
	public PurchaseRequestProductService() {
		
	}
	
	public List<PurchaseRequestProduct> findByIdPurchaseRequest(long idPurchaseRequest){
		
		List<PurchaseRequestProduct> purchaseRequestProducts = iPurchaseRequestProductRepository.findByIdPurchaseRequest(idPurchaseRequest);
		
		return purchaseRequestProducts;
	}
	
	public List<PurchaseRequestProduct> findByIdPurchaseRequestStatusInTwoNineAndUpdateDate(String updateDateOf, String updateDateTo){
		
		List<PurchaseRequestProduct> purchaseRequestProducts = iPurchaseRequestProductRepository.findByIdPurchaseRequestStatusInTwoNineAndUpdateDate(updateDateOf, updateDateTo);
		
		return purchaseRequestProducts;
	}
	
	public List<PurchaseRequestProduct> findByIdPurchaseRequestStatusInTwoNineAndExpirationDateGreatherThanNow(){
		
		List<PurchaseRequestProduct> purchaseRequestProducts = iPurchaseRequestProductRepository.findByIdPurchaseRequestStatusInTwoNineAndExpirationDateGreatherThanNow();
		
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
	
	public PurchaseRequestProduct updateById(PurchaseRequestProduct purchaseRequestProduct) throws IllegalArgumentException, IllegalAccessException, NoSuchFieldException, SecurityException {
	
		PurchaseRequestProduct purchaseRequestProductExisting = findById(purchaseRequestProduct.getId());
		
		List<Field> fields = Arrays.stream(purchaseRequestProductExisting.getClass().getDeclaredFields()).filter(x -> 
		x.getName() != "serialVersionUID" && 
		x.getName() != "Id"
		).collect(Collectors.toList());

		for (Field field : fields) {
		
			Field fieldObject = purchaseRequestProduct.getClass().getDeclaredField(field.getName());
			
			fieldObject.setAccessible(true);
			field.setAccessible(true);
			
			field.set(purchaseRequestProductExisting, fieldObject.get(purchaseRequestProduct));
		}
		
		purchaseRequestProductExisting = iPurchaseRequestProductRepository.save(purchaseRequestProductExisting);
		
		return purchaseRequestProductExisting;
	}
	
	public PurchaseRequestProduct updateAgreedPriceById(long id) {
		
		PurchaseRequestProduct purchaseRequestProduct = findById(id);
		
		List<PurchaseRequestProducer> purchaseRequestProducers = purchaseRequestProducerService.findByIdPurchaseRequestProductAndIsParticipantEqualToOne(purchaseRequestProduct.getId());
		
		if(purchaseRequestProducers.size() > 0) {
			
			long agreedPrice = purchaseRequestProducers.stream().mapToLong(x -> x.getPrice()).sum();
			
			purchaseRequestProduct.setAgreedPrice(agreedPrice);
			
			purchaseRequestService.updateTotalPriceById(purchaseRequestProduct.getIdPurchaseRequest());
			
			purchaseRequestProduct = iPurchaseRequestProductRepository.save(purchaseRequestProduct);
			
		}
		
		return purchaseRequestProduct;
		
	}
}
