DO
$$
BEGIN

CREATE TABLE public."Pallet" (
    "Id" integer NOT NULL,
    "RFID" character varying(8),
    "VirtualPalletId" integer,
    "Status" character varying NOT NULL
);

CREATE TABLE public."Program" (
    "Id" integer  NOT NULL,
    "Name" character varying NOT NULL,
    "Description" character varying,
    "NumberOfSteps" integer NOT NULL
);


CREATE TABLE public."ProgramStepsHistory" (
    "Id" integer NOT NULL,
    "PalletId" integer NOT NULL,
    "VirtualPalletId" integer NOT NULL,
    "ProgramId" integer NOT NULL,
    "StepId" integer NOT NULL,
    "Data" timestamp with time zone,
    "WorkspaceSlot" integer NOT NULL,
    "Result1" real,
    "Result2" real,
    "Result3" real,
    "Result4" real,
    "Result5" real,
    "Status" character varying NOT NULL
);

CREATE TABLE public."ProgramStepsInstruction" (
    "Id" integer NOT NULL,
    "ProgramId" integer NOT NULL,
    "Step" integer NOT NULL,
    "MachineMask" character varying NOT NULL,
    "Command" character varying NOT NULL,
    "Parameter1" character varying,
    "Parameter2" character varying,
    "Parameter3" character varying,
    "Parameter4" character varying,
    "Parameter5" character varying,
    "WorkspaceSlot" character varying NOT NULL
);

CREATE TABLE public."Status" (
    "Id" integer NOT NULL,
    "Name" character varying NOT NULL,
    "IsError" boolean NOT NULL
);

CREATE TABLE public."VirtualPallet" (
    "Id" integer NOT NULL,
    "ProgramId" integer NOT NULL,
    "StepId" integer NOT NULL,
    "Status" character varying NOT NULL,
    "PalletId" integer,
    "IsActive" boolean NOT NULL
);


ALTER TABLE ONLY public."ProgramStepsHistory"
    ADD CONSTRAINT "History_pkey" PRIMARY KEY ("Id");

ALTER TABLE ONLY public."Pallet"
    ADD CONSTRAINT "Pallet_pkey" PRIMARY KEY ("Id");

ALTER TABLE ONLY public."ProgramStepsHistory"
    ADD CONSTRAINT "ProgramStep" UNIQUE ("VirtualPalletId") INCLUDE ("StepId");

ALTER TABLE ONLY public."ProgramStepsInstruction"
    ADD CONSTRAINT "ProgramStepInstruction_key" PRIMARY KEY ("Id");

ALTER TABLE ONLY public."ProgramStepsInstruction"
    ADD CONSTRAINT "ProgramStepUnique" UNIQUE ("ProgramId", "Step");

ALTER TABLE ONLY public."Program"
    ADD CONSTRAINT "Program_pkey" PRIMARY KEY ("Id");

ALTER TABLE ONLY public."Pallet"
    ADD CONSTRAINT "RFID" UNIQUE ("RFID");

ALTER TABLE ONLY public."Status"
    ADD CONSTRAINT "Status_pkey" PRIMARY KEY ("Id");

ALTER TABLE ONLY public."Pallet"
    ADD CONSTRAINT "VID" UNIQUE ("VirtualPalletId");

ALTER TABLE ONLY public."VirtualPallet"
    ADD CONSTRAINT "VirtualPallet_pkey" PRIMARY KEY ("Id");

ALTER TABLE ONLY public."ProgramStepsHistory"
    ADD CONSTRAINT "History_Pallet" FOREIGN KEY ("PalletId") REFERENCES public."Pallet"("Id") NOT VALID;

ALTER TABLE ONLY public."ProgramStepsHistory"
    ADD CONSTRAINT "History_Program" FOREIGN KEY ("ProgramId") REFERENCES public."Program"("Id") NOT VALID;

ALTER TABLE ONLY public."ProgramStepsHistory"
    ADD CONSTRAINT "History_VirtualPallet" FOREIGN KEY ("VirtualPalletId") REFERENCES public."VirtualPallet"("Id") NOT VALID;


ALTER TABLE ONLY public."ProgramStepsInstruction"
    ADD CONSTRAINT "Instruction_Program" FOREIGN KEY ("ProgramId") REFERENCES public."Program"("Id") NOT VALID;


ALTER TABLE ONLY public."Pallet"
    ADD CONSTRAINT "Pallet_VirtualPallet" FOREIGN KEY ("VirtualPalletId") REFERENCES public."VirtualPallet"("Id") NOT VALID;


ALTER TABLE ONLY public."VirtualPallet"
    ADD CONSTRAINT "VirtualPallet_Pallet" FOREIGN KEY ("PalletId") REFERENCES public."Pallet"("Id") NOT VALID;


ALTER TABLE ONLY public."VirtualPallet"
    ADD CONSTRAINT "VirtualPallet_Program" FOREIGN KEY ("ProgramId") REFERENCES public."Program"("Id") NOT VALID;


ALTER TABLE ONLY public."VirtualPallet"
    ADD CONSTRAINT "VirtualPallet_Step" FOREIGN KEY ("ProgramId", "StepId") REFERENCES public."ProgramStepsInstruction"("ProgramId", "Step") NOT VALID;

END
$$