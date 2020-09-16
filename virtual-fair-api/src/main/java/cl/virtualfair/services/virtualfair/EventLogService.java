package cl.virtualfair.services.virtualfair;

import java.time.LocalDateTime;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import cl.virtualfair.models.virtualfair.EventLog;
import cl.virtualfair.repositories.IEventLogRepository;

@Service
public class EventLogService {

	@Autowired
	private IEventLogRepository iEventLogRepository;
	
	public EventLogService() {
		
	}
	
	public EventLog create(EventLog eventLog) {
		
		eventLog.setEventDate(LocalDateTime.now());

		eventLog = iEventLogRepository.save(eventLog);
		
		return eventLog;
	}
}
