package cl.virtualfair.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

import cl.virtualfair.models.virtualfair.PurchaseRequestStatus;

public interface IPurchaseRequestStatusRepository extends JpaRepository<PurchaseRequestStatus, Long> {

	@Query("SELECT PRS FROM PurchaseRequestStatus PRS")
	List<PurchaseRequestStatus> findAll();
}
