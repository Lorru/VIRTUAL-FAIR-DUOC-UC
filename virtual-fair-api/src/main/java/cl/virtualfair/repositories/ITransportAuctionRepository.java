package cl.virtualfair.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import cl.virtualfair.models.virtualfair.TransportAuction;

public interface ITransportAuctionRepository extends JpaRepository<TransportAuction, Long> {

	@Query("SELECT TA FROM TransportAuction TA")
	List<TransportAuction> findAll();
	
	@Query("SELECT TA FROM TransportAuction TA WHERE TA.Id IN :ids")
	List<TransportAuction> findByIds(@Param("ids") List<Long> ids);
	
}
