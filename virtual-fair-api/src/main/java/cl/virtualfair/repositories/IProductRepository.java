package cl.virtualfair.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;

import cl.virtualfair.models.virtualfair.Product;

public interface IProductRepository extends CrudRepository<Product, Long> {

	@Query("SELECT P FROM Product P")
	List<Product> findAll();
}
