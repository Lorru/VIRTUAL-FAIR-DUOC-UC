package cl.virtualfair.services.virtualfair;

import java.util.Collections;
import java.util.Comparator;
import java.util.List;
import java.util.stream.Collectors;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import cl.virtualfair.models.virtualfair.TransportAuctionCarrier;
import cl.virtualfair.repositories.ITransportAuctionCarrierRepository;

@Service
public class TransportAuctionCarrierService {

	@Autowired
	private ITransportAuctionCarrierRepository iTransportAuctionCarrierRepository;
	
	@Autowired
	private PurchaseRequestService purchaseRequestService;
	
	public TransportAuctionCarrierService() {
		
	}
	
	public List<TransportAuctionCarrier> findByIdTransportAuction(long idTransportAuction){
		
		List<TransportAuctionCarrier> transportAuctionCarriers = iTransportAuctionCarrierRepository.findByIdTransportAuction(idTransportAuction);
		
		return transportAuctionCarriers;
		
	}
	
	public List<TransportAuctionCarrier> findByIdPurchaseRequest(long idPurchaseRequest){
		
		List<TransportAuctionCarrier> transportAuctionCarriers = iTransportAuctionCarrierRepository.findByIdPurchaseRequest(idPurchaseRequest);
		
		return transportAuctionCarriers;
		
	}
	
	public TransportAuctionCarrier findByIdTransportAuctionAndIdCarrier(long idTransportAuction, long idCarrier) {
		
		TransportAuctionCarrier transportAuctionCarrier = iTransportAuctionCarrierRepository.findByIdTransportAuctionAndIdCarrier(idTransportAuction, idCarrier);
		
		return transportAuctionCarrier;
		
	}
	
	public TransportAuctionCarrier create(TransportAuctionCarrier transportAuctionCarrier) {
		
		transportAuctionCarrier.setIsParticipant(0);
		
		transportAuctionCarrier = iTransportAuctionCarrierRepository.save(transportAuctionCarrier);
		
		return transportAuctionCarrier;
		
	}
	
	public TransportAuctionCarrier getParticipantByIdPurchaseRequest(long idPurchaseRequest){
		
		List<TransportAuctionCarrier> transportAuctionCarriers = iTransportAuctionCarrierRepository.findByIdPurchaseRequest(idPurchaseRequest);
		
		TransportAuctionCarrier transportAuctionCarrierParticipant = Collections.min(transportAuctionCarriers, Comparator.comparing(x -> x.getPrice()));

		if(transportAuctionCarrierParticipant != null) {
		
			transportAuctionCarrierParticipant.setIsParticipant(1);
			
			iTransportAuctionCarrierRepository.save(transportAuctionCarrierParticipant);
			
			transportAuctionCarriers = transportAuctionCarriers.stream().filter(x -> x.getId() != transportAuctionCarrierParticipant.getId()).collect(Collectors.toList());
			
			for (TransportAuctionCarrier transportAuctionCarrierNotParticipant : transportAuctionCarriers) {
				
				transportAuctionCarrierNotParticipant.setIsParticipant(0);
				
				iTransportAuctionCarrierRepository.save(transportAuctionCarrierNotParticipant);
				
			}
			
		
			purchaseRequestService.updateTotalPriceById(transportAuctionCarrierParticipant.getTransportAuction().getIdPurchaseRequest());
		}
		
		
		return transportAuctionCarrierParticipant;
	}
	
	public TransportAuctionCarrier findByIdPurchaseRequestAndIsParticipantEqualToOne(long idPurchaseRequest) {
		
		TransportAuctionCarrier transportAuctionCarrier = iTransportAuctionCarrierRepository.findByIdPurchaseRequestAndIsParticipantEqualToOne(idPurchaseRequest);
		
		return transportAuctionCarrier;
		
	}
	
	public TransportAuctionCarrier findByIdPurchaseRequestAndIdCarrierAndIsParticipantEqualToOne(long idPurchaseRequest, long idCarrier) {
		
		TransportAuctionCarrier transportAuctionCarrier = iTransportAuctionCarrierRepository.findByIdPurchaseRequestAndIdCarrierAndIsParticipantEqualToOne(idPurchaseRequest, idCarrier);
		
		return transportAuctionCarrier;
		
	}
}
