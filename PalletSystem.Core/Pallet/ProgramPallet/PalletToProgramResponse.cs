namespace PalletSystem.Core.Pallet.ProgramPallet
{
    public class PalletToProgramResponse
    {
        public int PalletId { get; }
        public bool IsSuccess { get; }
        public string Comment { get; }

        private PalletToProgramResponse(int palletId, bool isSuccess, string comment)
        {
            PalletId = palletId;
            IsSuccess = isSuccess;
            Comment = comment;
        }

        public static PalletToProgramResponse Success(int palletId) => new PalletToProgramResponse(palletId, true, null);
        public static PalletToProgramResponse Failure(int palletId, string comment) => new PalletToProgramResponse(palletId, true, comment);

    }
}
