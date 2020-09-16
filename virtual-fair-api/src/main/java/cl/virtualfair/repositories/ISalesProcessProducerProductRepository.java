package cl.virtualfair.repositories;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import cl.virtualfair.models.virtualfair.SalesProcessProducerProduct;

public interface ISalesProcessProducerProductRepository extends JpaRepository<SalesProcessProducerProduct, Long> {

	@Query("SELECT SPPP FROM SalesProcessProducerProduct SPPP WHERE SPPP.IdProducer = :idProducer")
	List<SalesProcessProducerProduct> findByIdProducer(@Param("idProducer")long idProducer);
}
