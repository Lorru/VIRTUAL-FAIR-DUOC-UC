package cl.virtualfair.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

import cl.virtualfair.models.virtualfair.Contract;

public interface IContractRepository extends JpaRepository<Contract, Long> {

	@Query("SELECT C FROM Contract C")
	List<Contract> findAll();
}
