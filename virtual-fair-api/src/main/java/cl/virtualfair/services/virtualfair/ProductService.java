package cl.virtualfair.services.virtualfair;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import cl.virtualfair.models.virtualfair.Product;
import cl.virtualfair.repositories.IProductRepository;

@Service
public class ProductService {

	@Autowired
	private IProductRepository iProductRepository;
	
	public ProductService() {
		
	}
	
	public List<Product> findAll(){
		
		List<Product> products = iProductRepository.findAll();
		
		for (Product product : products) {
		
			String fileName = "products/" + product.getName().toLowerCase().replace(' ', '_') + ".png";
			
			fileName = "https://virtual-fair.s3-sa-east-1.amazonaws.com/" + fileName;
			
			//product.setImagePath(fileName);
			
		}
		
		return products;
	}
}