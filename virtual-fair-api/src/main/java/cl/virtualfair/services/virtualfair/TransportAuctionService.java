package cl.virtualfair.services.virtualfair;

import java.time.LocalDateTime;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import cl.virtualfair.models.virtualfair.PurchaseRequest;
import cl.virtualfair.models.virtualfair.TransportAuction;
import cl.virtualfair.repositories.ITransportAuctionRepository;

@Service
public class TransportAuctionService {

	@Autowired
	private ITransportAuctionRepository iTransportAuctionRepository;
	
	@Autowired
	private PurchaseRequestService purchaseRequestService;
	
	public TransportAuctionService() {
		
	}
	
	public List<TransportAuction> findAll(){
		
		List<TransportAuction> transportAuctions = iTransportAuctionRepository.findAll();
		
		return transportAuctions;
	}
	
	public List<TransportAuction> findByIsPublicEqualToOne(){
		
		List<TransportAuction> transportAuctions = iTransportAuctionRepository.findByIsPublicEqualToOne();
		
		return transportAuctions;
	}
	
	public List<TransportAuction> findByIsPublicEqualToZero(){
		
		List<TransportAuction> transportAuctions = iTransportAuctionRepository.findByIsPublicEqualToZero();
		
		return transportAuctions;
	}
	

	public List<TransportAuction> findByIdCarrierAndIsPublicEqualToOne(long idCarrier){
		
		List<TransportAuction> transportAuctions = iTransportAuctionRepository.findByIdCarrierAndIsPublicEqualToOne(idCarrier);
		
		return transportAuctions;
	}
	
	public TransportAuction create(TransportAuction transportAuction) {
		
		transportAuction.setCreationDate(LocalDateTime.now());
		transportAuction.setUpdateDate(LocalDateTime.now());
		
		PurchaseRequest purchaseRequest = purchaseRequestService.findById(transportAuction.getIdPurchaseRequest());
		
		if(purchaseRequest != null) {
			
			long idPurchaseRequestStatus = 4;
			
			purchaseRequest.setIdPurchaseRequestStatus(idPurchaseRequestStatus);
			
			purchaseRequestService.updateStatusById(purchaseRequest);
			
		}
		
		transportAuction = iTransportAuctionRepository.save(transportAuction);
		
		return transportAuction;
	}

	public TransportAuction findById(long id) {
		
		TransportAuction transportAuction = iTransportAuctionRepository.findById(id);
		
		return transportAuction;
		
	}
	
	public TransportAuction updateIsPublicById(TransportAuction transportAuction) {
		
		long id = transportAuction.getId();
		
		TransportAuction transportAuctionExisting = iTransportAuctionRepository.findById(id);
		
		transportAuctionExisting.setUpdateDate(LocalDateTime.now());
		transportAuctionExisting.setIsPublic(transportAuction.getIsPublic());

		transportAuctionExisting = iTransportAuctionRepository.save(transportAuctionExisting);
		
		return transportAuctionExisting;
		
	}
}
