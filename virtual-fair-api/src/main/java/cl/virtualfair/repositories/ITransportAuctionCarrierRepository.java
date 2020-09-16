package cl.virtualfair.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import cl.virtualfair.models.virtualfair.TransportAuctionCarrier;

public interface ITransportAuctionCarrierRepository extends JpaRepository<TransportAuctionCarrier, Long> {

	@Query("SELECT TAC FROM TransportAuctionCarrier TAC WHERE TAC.IdCarrier = :idCarrier")
	List<TransportAuctionCarrier> findByIdCarrier(@Param("idCarrier")long idCarrier);
	
}
