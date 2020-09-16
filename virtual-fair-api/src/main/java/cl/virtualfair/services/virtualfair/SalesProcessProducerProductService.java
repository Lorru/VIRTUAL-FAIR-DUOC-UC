package cl.virtualfair.services.virtualfair;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import cl.virtualfair.models.virtualfair.SalesProcessProducerProduct;
import cl.virtualfair.repositories.ISalesProcessProducerProductRepository;

@Service
public class SalesProcessProducerProductService {

	@Autowired
	private ISalesProcessProducerProductRepository iSalesProcessProducerProductRepository;
	
	public SalesProcessProducerProductService() {
		
	}
	
	public List<SalesProcessProducerProduct> findByIdProducer(long idProducer){
		
		List<SalesProcessProducerProduct> salesProcessProducerProducts = iSalesProcessProducerProductRepository.findByIdProducer(idProducer);
		
		return salesProcessProducerProducts;
	}
}
