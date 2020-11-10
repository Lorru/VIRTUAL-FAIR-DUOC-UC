package cl.virtualfair.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import cl.virtualfair.models.virtualfair.PurchaseRequestRemark;

public interface IPurchaseRequestRemarkRepository extends JpaRepository<PurchaseRequestRemark, Long> {

	@Query("SELECT PRR FROM PurchaseRequestRemark PRR WHERE PRR.IdPurchaseRequestStatus = :idPurchaseRequestStatus AND PRR.IdPurchaseRequest = :idPurchaseRequest")
	PurchaseRequestRemark findByIdPurchaseRequestStatusAndIdPurchaseRequest(@Param("idPurchaseRequestStatus")long idPurchaseRequestStatus, @Param("idPurchaseRequest")long idPurchaseRequest);
}
