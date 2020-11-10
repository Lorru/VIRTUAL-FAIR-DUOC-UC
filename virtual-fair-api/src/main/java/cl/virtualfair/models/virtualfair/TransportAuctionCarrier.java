package cl.virtualfair.models.virtualfair;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.SequenceGenerator;
import javax.persistence.Table;

import org.hibernate.annotations.Proxy;

@Entity
@Table(name="TRANSPORT_AUCTION_CARRIER")
@Proxy(lazy=false)
public class TransportAuctionCarrier implements Serializable {

	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.SEQUENCE ,generator="TRANSPORT_AUCTION_CARRIER_SEQ")
	@SequenceGenerator(name="TRANSPORT_AUCTION_CARRIER_SEQ", sequenceName="TRANSPORT_AUCTION_CARRIER_SEQ", allocationSize=1)
	@Column(name="ID")
	private long Id;
	
	@Column(name="ID_TRANSPORT_AUCTION")
	private Long IdTransportAuction;
	
	@Column(name="ID_CARRIER")
	private Long IdCarrier;
	
	@Column(name="PRICE")
	private Long Price;
	
	@Column(name="IS_PARTICIPANT")
	private Integer IsParticipant;
	
    @JoinColumn(name="ID_TRANSPORT_AUCTION", referencedColumnName="ID", insertable=false, updatable=false)
    @ManyToOne(fetch=FetchType.LAZY)
	private TransportAuction TransportAuction;
    
    @JoinColumn(name="ID_CARRIER", referencedColumnName="ID", insertable=false, updatable=false)
    @ManyToOne(fetch=FetchType.LAZY)
	private User Carrier;

	public TransportAuctionCarrier() {
	}    
    
	public TransportAuctionCarrier(long id) {
		Id = id;
	}

	public TransportAuctionCarrier(long id, Long idTransportAuction, Long idCarrier, Long price, Integer isParticipant,
			cl.virtualfair.models.virtualfair.TransportAuction transportAuction, User carrier) {
		Id = id;
		IdTransportAuction = idTransportAuction;
		IdCarrier = idCarrier;
		Price = price;
		IsParticipant = isParticipant;
		TransportAuction = transportAuction;
		Carrier = carrier;
	}

	public long getId() {
		return Id;
	}

	public void setId(long id) {
		Id = id;
	}

	public Long getIdTransportAuction() {
		return IdTransportAuction;
	}

	public void setIdTransportAuction(Long idTransportAuction) {
		IdTransportAuction = idTransportAuction;
	}

	public Long getIdCarrier() {
		return IdCarrier;
	}

	public void setIdCarrier(Long idCarrier) {
		IdCarrier = idCarrier;
	}

	public Long getPrice() {
		return Price;
	}

	public void setPrice(Long price) {
		Price = price;
	}

	public Integer getIsParticipant() {
		return IsParticipant;
	}

	public void setIsParticipant(Integer isParticipant) {
		IsParticipant = isParticipant;
	}

	public TransportAuction getTransportAuction() {
		return TransportAuction;
	}

	public void setTransportAuction(TransportAuction transportAuction) {
		TransportAuction = transportAuction;
	}

	public User getCarrier() {
		return Carrier;
	}

	public void setCarrier(User carrier) {
		Carrier = carrier;
	}
}
