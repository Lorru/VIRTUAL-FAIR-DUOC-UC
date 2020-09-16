package cl.virtualfair.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import cl.virtualfair.models.virtualfair.PurchaseRequest;

public interface IPurchaseRequestRepository extends JpaRepository<PurchaseRequest, Long> {

	@Query("SELECT PR FROM PurchaseRequest PR")
	List<PurchaseRequest> findAll();
	
	@Query("SELECT PR FROM PurchaseRequest PR WHERE PR.IdPurchaseRequestType = :idPurchaseRequestType")
	List<PurchaseRequest> findByIdPurchaseRequestType(@Param("idPurchaseRequestType")long idPurchaseRequestType);
	
	@Query("SELECT PR FROM PurchaseRequest PR WHERE PR.IdClient = :idClient")
	List<PurchaseRequest> findByIdClient(@Param("idClient")long idClient);
}
