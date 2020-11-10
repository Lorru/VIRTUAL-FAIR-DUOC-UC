package cl.virtualfair.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

import cl.virtualfair.models.virtualfair.Profile;

public interface IProfileRepository extends JpaRepository<Profile, Long> {

	@Query("SELECT P FROM Profile P")
	List<Profile> findAll();
	
}
