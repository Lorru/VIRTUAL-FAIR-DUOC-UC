package cl.virtualfair.services.virtualfair;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import cl.virtualfair.models.virtualfair.PurchaseRequest;
import cl.virtualfair.models.virtualfair.SalesProcess;
import cl.virtualfair.models.virtualfair.SalesProcessProducerProduct;
import cl.virtualfair.repositories.ISalesProcessRepository;

@Service
public class SalesProcessService {

	@Autowired
	private ISalesProcessRepository iSalesProcessRepository;
	
	@Autowired
	private PurchaseRequestService purchaseRequestService;
	
	@Autowired
	private SalesProcessProducerProductService salesProcessProducerProductService;
	
	public SalesProcessService() {
		
	}
	
	public List<SalesProcess> findByIdSalesProcessStatusAndIdPurchaseRequestType(long idSalesProcessStatus, long idPurchaseRequestType){
		
		List<SalesProcess> salesProcesses = new ArrayList<SalesProcess>();
		
		List<PurchaseRequest> purchaseRequests = purchaseRequestService.findByIdPurchaseRequestType(idPurchaseRequestType);
		
		List<Long> idsPurchaseRequest = purchaseRequests.stream().map(PurchaseRequest::getId).collect(Collectors.toList());
		
		salesProcesses = iSalesProcessRepository.findByIdSalesProcessStatusAndIdsPurchaseRequest(idSalesProcessStatus, idsPurchaseRequest);
		
		return salesProcesses;
	}
	
	public List<SalesProcess> findByIdProducerAndIdSalesProcessStatusAndIdPurchaseRequestType(long idProducer, long idSalesProcessStatus, long idPurchaseRequestType){
		
		List<SalesProcess> salesProcesses = new ArrayList<SalesProcess>();
		
		List<PurchaseRequest> purchaseRequests = purchaseRequestService.findByIdPurchaseRequestType(idPurchaseRequestType);
		
		List<SalesProcessProducerProduct> salesProcessProducerProducts = salesProcessProducerProductService.findByIdProducer(idProducer);
		
		List<Long> idsPurchaseRequest = purchaseRequests.stream().map(PurchaseRequest::getId).collect(Collectors.toList());
		
		List<Long> ids = salesProcessProducerProducts.stream().map(SalesProcessProducerProduct::getIdSalesProcess).collect(Collectors.toList());
		
		salesProcesses = iSalesProcessRepository.findByIdSalesProcessStatusAndIdsPurchaseRequestAndIds(idSalesProcessStatus, idsPurchaseRequest, ids);
		
		return salesProcesses;
	}
}
