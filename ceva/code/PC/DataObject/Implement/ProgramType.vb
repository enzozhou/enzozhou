Namespace BusinessObject

    Public Class ProgramType
        Public Enum enuType
            RegionDC = 1
        End Enum

        Public Enum PhaseType
            Phase10 = 10
            Phase15 = 15
            Phase20 = 20
        End Enum

        Public Shared Type As enuType = enuType.RegionDC
        Public Shared DateFormat As String
        Public Shared DateTimeFormat As String
        Public Shared Phase As PhaseType = PhaseType.Phase15

    End Class





End Namespace
