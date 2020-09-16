package cl.virtualfair.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import cl.virtualfair.models.virtualfair.User;

@Repository
public interface IUserRepository extends JpaRepository<User, Long> {

	//@Procedure(procedureName = "FIND_ALL_USER")
	@Query("SELECT U FROM User U")
	List<User> findAll();
	
	@Query("SELECT U FROM User U WHERE LOWER(U.Email) LIKE LOWER(CONCAT('%', :searcher,'%')) OR LOWER(U.FullName) LIKE LOWER(CONCAT('%', :searcher,'%'))")
	List<User> findAll(@Param("searcher") String searcher);
	
	//@Procedure(procedureName = "FIND_BY_EMAIL_USER")
	@Query("SELECT U FROM User U WHERE U.Email = :email")
	User findByEmail(@Param("email") String email);
	
	@Query("SELECT U FROM User U WHERE U.Id = :id")
	User findById(@Param("id") long id);
}
