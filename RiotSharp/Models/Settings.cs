using Newtonsoft.Json;

namespace RiotSharp.Models
{
    internal class Settings
    {
        public class FloatingText
        {
            [JsonProperty("Damage_Enabled")]
            public bool? DamageEnabled;

            [JsonProperty("Dodge_Enabled")]
            public bool? DodgeEnabled;

            [JsonProperty("EnemyDamage_Enabled")]
            public bool? EnemyDamageEnabled;

            [JsonProperty("Experience_Enabled")]
            public bool? ExperienceEnabled;

            [JsonProperty("Gold_Enabled")]
            public bool? GoldEnabled;

            [JsonProperty("Heal_Enabled")]
            public bool? HealEnabled;

            [JsonProperty("Invulnerable_Enabled")]
            public bool? InvulnerableEnabled;

            [JsonProperty("Level_Enabled")]
            public bool? LevelEnabled;

            [JsonProperty("ManaDamage_Enabled")]
            public bool? ManaDamageEnabled;

            [JsonProperty("QuestReceived_Enabled")]
            public bool? QuestReceivedEnabled;

            [JsonProperty("Score_Enabled")]
            public bool? ScoreEnabled;

            [JsonProperty("Special_Enabled")]
            public bool? SpecialEnabled;
        }

        public class General
        {
            [JsonProperty("AutoAcquireTarget")]
            public bool? AutoAcquireTarget;

            [JsonProperty("BindSysKeys")]
            public bool? BindSysKeys;

            [JsonProperty("ClampCastTargetLocationWithinMaxRange")]
            public bool? ClampCastTargetLocationWithinMaxRange;

            [JsonProperty("CursorOverride")]
            public bool? CursorOverride;

            [JsonProperty("CursorScale")]
            public double? CursorScale;

            [JsonProperty("EnableAudio")]
            public bool? EnableAudio;

            [JsonProperty("EnableTargetedAttackMove")]
            public bool? EnableTargetedAttackMove;

            [JsonProperty("GameMouseSpeed")]
            public int? GameMouseSpeed;

            [JsonProperty("HideEyeCandy")]
            public bool? HideEyeCandy;

            [JsonProperty("OSXMouseAcceleration")]
            public bool? OSXMouseAcceleration;

            [JsonProperty("PredictMovement")]
            public bool? PredictMovement;

            [JsonProperty("PreferOpenGLLegacyMode")]
            public bool? PreferOpenGLLegacyMode;

            [JsonProperty("RecommendJunglePaths")]
            public bool? RecommendJunglePaths;

            [JsonProperty("RelativeTeamColors")]
            public bool? RelativeTeamColors;

            [JsonProperty("ShowCursorLocator")]
            public bool? ShowCursorLocator;

            [JsonProperty("ShowGodray")]
            public bool? ShowGodray;

            [JsonProperty("ShowTurretRangeIndicators")]
            public bool? ShowTurretRangeIndicators;

            [JsonProperty("SnapCameraOnRespawn")]
            public bool? SnapCameraOnRespawn;

            [JsonProperty("TargetChampionsOnlyAsToggle")]
            public bool? TargetChampionsOnlyAsToggle;

            [JsonProperty("ThemeMusic")]
            public int? ThemeMusic;

            [JsonProperty("WaitForVerticalSync")]
            public bool? WaitForVerticalSync;

            [JsonProperty("WindowMode")]
            public int? WindowMode;
        }

        public class HUD
        {
            [JsonProperty("AutoDisplayTarget")]
            public bool? AutoDisplayTarget;

            [JsonProperty("CameraLockMode")]
            public int? CameraLockMode;

            [JsonProperty("ChatChannelVisibility")]
            public int? ChatChannelVisibility;

            [JsonProperty("ChatScale")]
            public int? ChatScale;

            [JsonProperty("DisableHudSpellClick")]
            public bool? DisableHudSpellClick;

            [JsonProperty("DrawHealthBars")]
            public bool? DrawHealthBars;

            [JsonProperty("EmotePopupUIDisplayMode")]
            public int? EmotePopupUIDisplayMode;

            [JsonProperty("EmoteSize")]
            public int? EmoteSize;

            [JsonProperty("EnableLineMissileVis")]
            public bool? EnableLineMissileVis;

            [JsonProperty("EternalsMilestoneDisplayMode")]
            public int? EternalsMilestoneDisplayMode;

            [JsonProperty("FlashScreenWhenDamaged")]
            public bool? FlashScreenWhenDamaged;

            [JsonProperty("FlashScreenWhenStunned")]
            public bool? FlashScreenWhenStunned;

            [JsonProperty("FlipMiniMap")]
            public bool? FlipMiniMap;

            [JsonProperty("GlobalScale")]
            public double? GlobalScale;

            [JsonProperty("HideReciprocityFist")]
            public bool? HideReciprocityFist;

            [JsonProperty("KeyboardScrollSpeed")]
            public double? KeyboardScrollSpeed;

            [JsonProperty("MapScrollSpeed")]
            public double? MapScrollSpeed;

            [JsonProperty("MiddleClickDragScrollEnabled")]
            public bool? MiddleClickDragScrollEnabled;

            [JsonProperty("MinimapMoveSelf")]
            public bool? MinimapMoveSelf;

            [JsonProperty("MinimapScale")]
            public double? MinimapScale;

            [JsonProperty("MirroredScoreboard")]
            public bool? MirroredScoreboard;

            [JsonProperty("NumericCooldownFormat")]
            public int? NumericCooldownFormat;

            [JsonProperty("ObjectiveVoteScale")]
            public double? ObjectiveVoteScale;

            [JsonProperty("ScrollSmoothingEnabled")]
            public bool? ScrollSmoothingEnabled;

            [JsonProperty("ShowAllChannelChat")]
            public bool? ShowAllChannelChat;

            [JsonProperty("ShowAlliedChat")]
            public bool? ShowAlliedChat;

            [JsonProperty("ShowAttackRadius")]
            public bool? ShowAttackRadius;

            [JsonProperty("ShowNeutralCamps")]
            public bool? ShowNeutralCamps;

            [JsonProperty("ShowOffScreenPointsOfInterest")]
            public bool? ShowOffScreenPointsOfInterest;

            [JsonProperty("ShowSpellCosts")]
            public bool? ShowSpellCosts;

            [JsonProperty("ShowSpellRecommendations")]
            public bool? ShowSpellRecommendations;

            [JsonProperty("ShowSummonerNames")]
            public int? ShowSummonerNames;

            [JsonProperty("ShowSummonerNamesInScoreboard")]
            public bool? ShowSummonerNamesInScoreboard;

            [JsonProperty("ShowTeamFramesOnLeft")]
            public bool? ShowTeamFramesOnLeft;

            [JsonProperty("ShowTimestamps")]
            public bool? ShowTimestamps;

            [JsonProperty("SmartCastOnKeyRelease")]
            public bool? SmartCastOnKeyRelease;

            [JsonProperty("SmartCastWithIndicator_CastWhenNewSpellSelected")]
            public bool? SmartCastWithIndicatorCastWhenNewSpellSelected;
        }

        public class LossOfControl
        {
            [JsonProperty("LossOfControlEnabled")]
            public bool? LossOfControlEnabled;

            [JsonProperty("ShowSlows")]
            public bool? ShowSlows;
        }

        public class Performance
        {
            [JsonProperty("EnableHUDAnimations")]
            public bool? EnableHUDAnimations;
        }

        public class Root
        {
            [JsonProperty("FloatingText")]
            public FloatingText FloatingText;

            [JsonProperty("General")]
            public General General;

            [JsonProperty("HUD")]
            public HUD HUD;

            [JsonProperty("LossOfControl")]
            public LossOfControl LossOfControl;

            [JsonProperty("Performance")]
            public Performance Performance;

            [JsonProperty("Voice")]
            public Voice Voice;

            [JsonProperty("Volume")]
            public Volume Volume;
        }

        public class Voice
        {
            [JsonProperty("ShowVoiceChatHalos")]
            public bool? ShowVoiceChatHalos;

            [JsonProperty("ShowVoicePanelWithScoreboard")]
            public bool? ShowVoicePanelWithScoreboard;
        }

        public class Volume
        {
            [JsonProperty("AmbienceMute")]
            public bool? AmbienceMute;

            [JsonProperty("AmbienceVolume")]
            public double? AmbienceVolume;

            [JsonProperty("AnnouncerMute")]
            public bool? AnnouncerMute;

            [JsonProperty("AnnouncerVolume")]
            public double? AnnouncerVolume;

            [JsonProperty("MasterMute")]
            public bool? MasterMute;

            [JsonProperty("MasterVolume")]
            public double? MasterVolume;

            [JsonProperty("MusicMute")]
            public bool? MusicMute;

            [JsonProperty("MusicVolume")]
            public double? MusicVolume;

            [JsonProperty("PingsMute")]
            public bool? PingsMute;

            [JsonProperty("PingsVolume")]
            public double? PingsVolume;

            [JsonProperty("SfxMute")]
            public bool? SfxMute;

            [JsonProperty("SfxVolume")]
            public double? SfxVolume;

            [JsonProperty("VoiceMute")]
            public bool? VoiceMute;

            [JsonProperty("VoiceVolume")]
            public double? VoiceVolume;
        }
    }
}
