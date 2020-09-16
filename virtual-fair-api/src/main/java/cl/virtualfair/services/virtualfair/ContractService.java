package cl.virtualfair.services.virtualfair;

import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import cl.virtualfair.models.virtualfair.Contract;
import cl.virtualfair.repositories.IContractRepository;

@Service
public class ContractService {

	@Autowired
	private IContractRepository iContractRepository;
	
	public ContractService() {
		
	}
	
	public List<Contract> findAll(String searcher){
		
		List<Contract> contracts = new ArrayList<Contract>();
		
		contracts = iContractRepository.findAll();
		
		return contracts;
	}
}
