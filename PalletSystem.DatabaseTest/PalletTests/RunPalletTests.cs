using MongoDB.Bson;
using PalletSystem.Core.Pallet.Run;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PalletSystem.DatabaseTest.PalletTests
{
    [Collection("Database")]
    public class RunPalletTests : DatabaseTest
    {
        [Fact(DisplayName = "Run pallet on valid data")]
        public async Task RunPalletSuccess()
        {
            var service = new PalletRunService(new PalletRunAccess());
            var palletId = await PalletHelperMethods.InsertPallet();
            var programId = await PalletHelperMethods.InsertProgram();

            var result = await service.RunPallet(new PalletRunRequest(palletId, programId));

            Assert.Equal(PalletRunResult.PalletRun, result);
        }

        [Fact(DisplayName = "Run pallet without program gives error")]
        public async Task RunPalletWithoutProgramFailure()
        {
            var service = new PalletRunService(new PalletRunAccess());
            var palletId = await PalletHelperMethods.InsertPallet();

            var result = await service.RunPallet(new PalletRunRequest(palletId, ObjectId.Empty.ToString()));

            Assert.Equal(PalletRunResult.ProgramNotExists, result);
        }

        [Fact(DisplayName = "Run pallet without pallet gives error")]
        public async Task RunPalletWithoutPalletFailure()
        {
            var service = new PalletRunService(new PalletRunAccess());
            var programId = await PalletHelperMethods.InsertProgram();

            var result = await service.RunPallet(new PalletRunRequest(ObjectId.Empty.ToString(), programId));

            Assert.Equal(PalletRunResult.PalletNotExists, result);
        }

        [Fact(DisplayName = "Run not ready pallet gives error")]
        public async Task RunNotReadyPalletFailure()
        {
            var service = new PalletRunService(new PalletRunAccess());
            var palletId = await PalletHelperMethods.InsertPallet(status: Core.Pallet.Constant.PalletStatus.Running);
            var programId = await PalletHelperMethods.InsertProgram();

            var result = await service.RunPallet(new PalletRunRequest(palletId, programId));

            Assert.Equal(PalletRunResult.PalletNotReady, result);
        }
    }
}
