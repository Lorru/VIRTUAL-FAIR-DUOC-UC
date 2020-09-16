package cl.virtualfair.services.virtualfair;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import cl.virtualfair.models.virtualfair.SalesProcessStatus;
import cl.virtualfair.repositories.ISalesProcessStatusRepository;

@Service
public class SalesProcessStatusService {

	@Autowired
	private ISalesProcessStatusRepository iSalesProcessStatusRepository;
	
	public SalesProcessStatusService() {
		
	}
	
	public List<SalesProcessStatus> findAll(){
		
		List<SalesProcessStatus> salesProcessStatus = iSalesProcessStatusRepository.findAll();
		
		return salesProcessStatus;
	}
}
