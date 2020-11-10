package cl.virtualfair.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import cl.virtualfair.models.virtualfair.TransportAuctionCarrier;

public interface ITransportAuctionCarrierRepository extends JpaRepository<TransportAuctionCarrier, Long> {

	@Query("SELECT TAC FROM TransportAuctionCarrier TAC WHERE TAC.IdTransportAuction = :idTransportAuction")
	List<TransportAuctionCarrier> findByIdTransportAuction(@Param("idTransportAuction")long idTransportAuction);

	@Query("SELECT TAC FROM TransportAuctionCarrier TAC JOIN TAC.TransportAuction TA WHERE TA.IdPurchaseRequest = :idPurchaseRequest")
	List<TransportAuctionCarrier> findByIdPurchaseRequest(@Param("idPurchaseRequest")long idPurchaseRequest);
	
	@Query("SELECT TAC FROM TransportAuctionCarrier TAC WHERE TAC.IdTransportAuction = :idTransportAuction AND TAC.IdCarrier = :idCarrier")
	TransportAuctionCarrier findByIdTransportAuctionAndIdCarrier(@Param("idTransportAuction")long idTransportAuction, @Param("idCarrier")long idCarrier);
	
	@Query("SELECT TAC FROM TransportAuctionCarrier TAC JOIN TAC.TransportAuction TA WHERE TA.IdPurchaseRequest = :idPurchaseRequest AND TAC.IsParticipant = 1")
	TransportAuctionCarrier findByIdPurchaseRequestAndIsParticipantEqualToOne(@Param("idPurchaseRequest")long idPurchaseRequest);
}
