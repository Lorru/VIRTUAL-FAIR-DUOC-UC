package cl.virtualfair.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

import cl.virtualfair.models.virtualfair.PurchaseRequestType;

public interface IPurchaseRequestTypeRepository extends JpaRepository<PurchaseRequestType, Long> {

	@Query("SELECT PRT FROM PurchaseRequestType PRT")
	List<PurchaseRequestType> findAll();
}
