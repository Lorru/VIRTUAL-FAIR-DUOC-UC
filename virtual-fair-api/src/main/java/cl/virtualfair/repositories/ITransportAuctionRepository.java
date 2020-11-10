package cl.virtualfair.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import cl.virtualfair.models.virtualfair.TransportAuction;

public interface ITransportAuctionRepository extends JpaRepository<TransportAuction, Long> {

	@Query("SELECT TA FROM TransportAuction TA")
	List<TransportAuction> findAll();
	
	@Query("SELECT TA FROM TransportAuction TA WHERE TA.IsPublic = 1")
	List<TransportAuction> findByIsPublicEqualToOne();
	
	@Query("SELECT DISTINCT TA FROM TransportAuctionCarrier TAC JOIN TAC.TransportAuction TA WHERE TAC.IdCarrier = :idCarrier AND TA.IsPublic = 1")
	List<TransportAuction> findByIdCarrierAndIsPublicEqualToOne(@Param("idCarrier")long idCarrier);
	
	@Query("SELECT TA FROM TransportAuction TA WHERE TA.Id = :id")
	TransportAuction findById(@Param("id")long id);
}
