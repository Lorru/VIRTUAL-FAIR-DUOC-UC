package cl.virtualfair.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.data.repository.query.Param;

import cl.virtualfair.models.virtualfair.PurchaseRequestProducer;

public interface IPurchaseRequestProducerRepository extends CrudRepository<PurchaseRequestProducer, Long> {

	@Query("SELECT DISTINCT PRP FROM PurchaseRequestProducer PRP JOIN PRP.PurchaseRequestProduct PRPP WHERE PRPP.IdPurchaseRequest = :idPurchaseRequest")
	List<PurchaseRequestProducer> findByIdPurchaseRequest(@Param("idPurchaseRequest")long idPurchaseRequest);
	
	@Query("SELECT DISTINCT PRP FROM PurchaseRequestProducer PRP JOIN PRP.PurchaseRequestProduct PRPP WHERE PRPP.IdPurchaseRequest = :idPurchaseRequest AND PRP.IdProducer = :idProducer")
	List<PurchaseRequestProducer> findByIdPurchaseRequestAndIdProducer(@Param("idPurchaseRequest")long idPurchaseRequest, @Param("idProducer")long idProducer);
	
	@Query("SELECT PRP FROM PurchaseRequestProducer PRP WHERE PRP.IdPurchaseRequestProduct = :idPurchaseRequestProduct AND PRP.IdProducer = :idProducer")
	PurchaseRequestProducer findByIdPurchaseRequestProductAndIdProducer(@Param("idPurchaseRequestProduct")long idPurchaseRequestProduct, @Param("idProducer")long idProducer);
	
	@Query("SELECT PRP FROM PurchaseRequestProducer PRP WHERE PRP.Id = :id")
	PurchaseRequestProducer findById(@Param("id")long id);
	
	@Query("SELECT PRP FROM PurchaseRequestProducer PRP WHERE PRP.IdPurchaseRequestProduct = :idPurchaseRequestProduct AND PRP.IsParticipant = 1")
	PurchaseRequestProducer findByIdPurchaseRequestProductAndIsParticipantEqualToOne(@Param("idPurchaseRequestProduct")long idPurchaseRequestProduct);
}
