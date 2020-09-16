package cl.virtualfair.repositories;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import cl.virtualfair.models.virtualfair.SessionToken;

public interface ISessionTokenRepository extends JpaRepository<SessionToken, Long> {

	@Query("SELECT S FROM SessionToken S WHERE S.Token = :token AND S.Host = :host")
	SessionToken findByTokenAndHost(@Param("token")String token, @Param("host")String host);

}
