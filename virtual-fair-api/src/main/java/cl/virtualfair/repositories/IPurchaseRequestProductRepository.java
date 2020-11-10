package cl.virtualfair.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.data.repository.query.Param;

import cl.virtualfair.models.virtualfair.PurchaseRequestProduct;

public interface IPurchaseRequestProductRepository extends CrudRepository<PurchaseRequestProduct, Long> {

	@Query("SELECT PRP FROM PurchaseRequestProduct PRP WHERE PRP.IdPurchaseRequest = :idPurchaseRequest")
	List<PurchaseRequestProduct> findByIdPurchaseRequest(@Param("idPurchaseRequest") long idPurchaseRequest);
	
	@Query("SELECT PRP FROM PurchaseRequestProduct PRP WHERE PRP.IdPurchaseRequest = :idPurchaseRequest AND PRP.IdProduct = :idProduct")
	PurchaseRequestProduct findByIdPurchaseRequestAndIdProduct(@Param("idPurchaseRequest")long idPurchaseRequest, @Param("idProduct")long idProduct);
	
	@Query("SELECT PRP FROM PurchaseRequestProduct PRP WHERE PRP.Id = :id")
	PurchaseRequestProduct findById(@Param("id")long id);
}
