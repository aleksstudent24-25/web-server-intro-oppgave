class AdminVerification
{
    public Guid VerificationId { get; set; }
    public AdminVerification(Guid id)
    {
        VerificationId = id;
    }
}