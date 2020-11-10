package cl.virtualfair.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import cl.virtualfair.models.virtualfair.PurchaseRequest;

public interface IPurchaseRequestRepository extends JpaRepository<PurchaseRequest, Long> {
	
	@Query("SELECT PR FROM PurchaseRequest PR WHERE PR.IdPurchaseRequestType = :idPurchaseRequestType AND PR.IsPublic = 1")
	List<PurchaseRequest> findByIdPurchaseRequestTypeAndIsPublicEqualToOne(@Param("idPurchaseRequestType")long idPurchaseRequestType);
	
	@Query("SELECT DISTINCT PR FROM PurchaseRequestProducer PRPP JOIN PRPP.PurchaseRequestProduct PRP JOIN PRP.PurchaseRequest PR WHERE PR.IdPurchaseRequestType = :idPurchaseRequestType AND PRPP.IdProducer = :idProducer AND PR.IsPublic = 1")
	List<PurchaseRequest> findByIdPurchaseRequestTypeAndIdProducerAndIsPublicEqualToOne(@Param("idPurchaseRequestType")long idPurchaseRequestType, @Param("idProducer")long idProducer);
	
	@Query("SELECT PR FROM PurchaseRequest PR WHERE PR.IsPublic = 0")
	List<PurchaseRequest> findByIsPublicEqualToZero();
	
	@Query("SELECT PR FROM PurchaseRequest PR WHERE PR.IsPublic = 1")
	List<PurchaseRequest> findByIsPublicEqualToOne();
	
	@Query("SELECT PR FROM PurchaseRequest PR WHERE PR.IdPurchaseRequestStatus = :idPurchaseRequestStatus AND PR.IdPurchaseRequestType = :idPurchaseRequestType")
	List<PurchaseRequest> findByIdPurchaseRequestStatusAndIdPurchaseRequestType(@Param("idPurchaseRequestStatus")long idPurchaseRequestStatus, @Param("idPurchaseRequestType")long idPurchaseRequestType);
	
	@Query("SELECT PR FROM PurchaseRequest PR WHERE PR.IdClient = :idClient")
	List<PurchaseRequest> findByIdClient(@Param("idClient")long idClient);
	
	@Query("SELECT PR FROM PurchaseRequest PR WHERE PR.Id = :id")
	PurchaseRequest findById(@Param("id")long id);
}
