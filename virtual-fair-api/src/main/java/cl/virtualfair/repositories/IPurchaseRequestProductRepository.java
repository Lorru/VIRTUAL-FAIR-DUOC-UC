package cl.virtualfair.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.data.repository.query.Param;

import cl.virtualfair.models.virtualfair.PurchaseRequestProduct;

public interface IPurchaseRequestProductRepository extends CrudRepository<PurchaseRequestProduct, Long> {

	@Query("SELECT PRP FROM PurchaseRequestProduct PRP WHERE PRP.IdPurchaseRequest = :idPurchaseRequest")
	List<PurchaseRequestProduct> findByIdPurchaseRequest(@Param("idPurchaseRequest") long idPurchaseRequest);
	
	@Query("SELECT PRP FROM PurchaseRequestProduct PRP JOIN PRP.PurchaseRequest PR WHERE PR.IdPurchaseRequestStatus IN (2, 9) AND TO_CHAR(PR.UpdateDate, 'YYYY-MM-DD') BETWEEN :updateDateOf AND :updateDateTo")
	List<PurchaseRequestProduct> findByIdPurchaseRequestStatusInTwoNineAndUpdateDate(@Param("updateDateOf")String updateDateOf, @Param("updateDateTo")String updateDateTo);

	@Query("SELECT DISTINCT PRP FROM PurchaseRequestProducer PRPP JOIN PRPP.PurchaseRequestProduct PRP JOIN PRP.PurchaseRequest PR WHERE PRP.Weight > 0 AND PR.IdPurchaseRequestStatus IN (2, 9) AND TO_CHAR(PRPP.ExpirationDate, 'YYYY-MM-DD') > TO_CHAR(SYSDATE, 'YYYY-MM-DD')")
	List<PurchaseRequestProduct> findByIdPurchaseRequestStatusInTwoNineAndExpirationDateGreatherThanNow();
	
	@Query("SELECT PRP FROM PurchaseRequestProduct PRP WHERE PRP.IdPurchaseRequest = :idPurchaseRequest AND PRP.IdProduct = :idProduct")
	PurchaseRequestProduct findByIdPurchaseRequestAndIdProduct(@Param("idPurchaseRequest")long idPurchaseRequest, @Param("idProduct")long idProduct);
	
	@Query("SELECT PRP FROM PurchaseRequestProduct PRP WHERE PRP.Id = :id")
	PurchaseRequestProduct findById(@Param("id")long id);
}
