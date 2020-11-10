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
@Table(name="PURCHASE_REQUEST_REMARK")
@Proxy(lazy=false)
public class PurchaseRequestRemark implements Serializable {

	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.SEQUENCE ,generator="PURCHASE_REQUEST_REMARK_SEQ")
	@SequenceGenerator(name="PURCHASE_REQUEST_REMARK_SEQ", sequenceName="PURCHASE_REQUEST_REMARK_SEQ", allocationSize=1)
	@Column(name="ID")
	private long Id;

	@Column(name="ID_PURCHASE_REQUEST_STATUS")
	private Long IdPurchaseRequestStatus;
	
	@Column(name="ID_PURCHASE_REQUEST")
	private Long IdPurchaseRequest;
	
	@Column(name="REMARK")
	private String Remark;	
	
    @JoinColumn(name="ID_PURCHASE_REQUEST_STATUS", referencedColumnName="ID", insertable=false, updatable=false)
    @ManyToOne(fetch=FetchType.LAZY)
	private PurchaseRequestStatus PurchaseRequestStatus;
	
    @JoinColumn(name="ID_PURCHASE_REQUEST", referencedColumnName="ID", insertable=false, updatable=false)
    @ManyToOne(fetch=FetchType.LAZY)
	private PurchaseRequest PurchaseRequest;

	public PurchaseRequestRemark() {
	}
    
	public PurchaseRequestRemark(long id) {
		Id = id;
	}
    
	public PurchaseRequestRemark(long id, Long idPurchaseRequestStatus, Long idPurchaseRequest, String remark,
			cl.virtualfair.models.virtualfair.PurchaseRequestStatus purchaseRequestStatus,
			cl.virtualfair.models.virtualfair.PurchaseRequest purchaseRequest) {
		Id = id;
		IdPurchaseRequestStatus = idPurchaseRequestStatus;
		IdPurchaseRequest = idPurchaseRequest;
		Remark = remark;
		PurchaseRequestStatus = purchaseRequestStatus;
		PurchaseRequest = purchaseRequest;
	}

	public long getId() {
		return Id;
	}

	public void setId(long id) {
		Id = id;
	}

	public Long getIdPurchaseRequestStatus() {
		return IdPurchaseRequestStatus;
	}

	public void setIdPurchaseRequestStatus(Long idPurchaseRequestStatus) {
		IdPurchaseRequestStatus = idPurchaseRequestStatus;
	}

	public Long getIdPurchaseRequest() {
		return IdPurchaseRequest;
	}

	public void setIdPurchaseRequest(Long idPurchaseRequest) {
		IdPurchaseRequest = idPurchaseRequest;
	}

	public String getRemark() {
		return Remark;
	}

	public void setRemark(String remark) {
		Remark = remark;
	}

	public PurchaseRequestStatus getPurchaseRequestStatus() {
		return PurchaseRequestStatus;
	}

	public void setPurchaseRequestStatus(PurchaseRequestStatus purchaseRequestStatus) {
		PurchaseRequestStatus = purchaseRequestStatus;
	}

	public PurchaseRequest getPurchaseRequest() {
		return PurchaseRequest;
	}

	public void setPurchaseRequest(PurchaseRequest purchaseRequest) {
		PurchaseRequest = purchaseRequest;
	}
}
