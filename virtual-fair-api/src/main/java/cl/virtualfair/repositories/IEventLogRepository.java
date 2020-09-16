package cl.virtualfair.repositories;

import org.springframework.data.jpa.repository.JpaRepository;

import cl.virtualfair.models.virtualfair.EventLog;

public interface IEventLogRepository extends JpaRepository<EventLog, Long> {

}
