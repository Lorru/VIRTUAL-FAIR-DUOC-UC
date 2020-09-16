package cl.virtualfair.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import cl.virtualfair.models.virtualfair.SalesProcess;

public interface ISalesProcessRepository extends JpaRepository<SalesProcess, Long> {

	@Query("SELECT SP FROM SalesProcess SP WHERE SP.IdSalesProcessStatus = :idSalesProcessStatus AND SP.IdPurchaseRequest IN :idsPurchaseRequest")
	List<SalesProcess> findByIdSalesProcessStatusAndIdsPurchaseRequest(@Param("idSalesProcessStatus")long idSalesProcessStatus, @Param("idsPurchaseRequest")List<Long> idsPurchaseRequest);
	
	@Query("SELECT SP FROM SalesProcess SP WHERE SP.IdSalesProcessStatus = :idSalesProcessStatus AND SP.IdPurchaseRequest IN :idsPurchaseRequest AND SP.Id IN :ids")
	List<SalesProcess> findByIdSalesProcessStatusAndIdsPurchaseRequestAndIds(@Param("idSalesProcessStatus")long idSalesProcessStatus, @Param("idsPurchaseRequest")List<Long> idsPurchaseRequest, @Param("ids")List<Long> ids);
}
