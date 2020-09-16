package cl.virtualfair.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

import cl.virtualfair.models.virtualfair.SalesProcessStatus;

public interface ISalesProcessStatusRepository extends JpaRepository<SalesProcessStatus, Long> {

	@Query("SELECT SPS FROM SalesProcessStatus SPS")
	List<SalesProcessStatus> findAll();
}
