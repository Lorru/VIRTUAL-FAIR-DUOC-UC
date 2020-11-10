package cl.virtualfair.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import cl.virtualfair.models.virtualfair.Contract;

public interface IContractRepository extends JpaRepository<Contract, Long> {
	
	@Query("SELECT C FROM Contract C")
	List<Contract> findAll();
	
	@Query("SELECT C FROM Contract C WHERE C.IdUser = :idUser")
	Contract findByIdUser(@Param("idUser") long idUser);
	
	@Query("SELECT C FROM Contract C WHERE C.Id = :id")
	Contract findById(@Param("id") long id);
}
