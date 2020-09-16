package cl.virtualfair.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import cl.virtualfair.models.virtualfair.Profile;

public interface IProfileRepository extends JpaRepository<Profile, Long> {

	@Query("SELECT P FROM Profile P")
	List<Profile> findAll();

	@Query("SELECT P FROM Profile P WHERE P.Id = :id")
	Profile findById(@Param("id")long id);
	
}
