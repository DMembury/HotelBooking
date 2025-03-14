﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Waracle.HotelBooking.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Waracle.HotelBooking.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The given hotel ID was not found..
        /// </summary>
        internal static string AvailableRooms_Get_BadRequest_BadHotel {
            get {
                return ResourceManager.GetString("AvailableRooms_Get_BadRequest_BadHotel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No rooms are available in the given hotel for the given date range, or the required occupancy..
        /// </summary>
        internal static string AvailableRooms_Get_NotFound_NoAvailableRooms {
            get {
                return ResourceManager.GetString("AvailableRooms_Get_NotFound_NoAvailableRooms", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to find a booking for the given ID..
        /// </summary>
        internal static string BookingInfo_Get_NotFound_BadId {
            get {
                return ResourceManager.GetString("BookingInfo_Get_NotFound_BadId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The end-date for the booking cannot be before the start-date..
        /// </summary>
        internal static string BookRoom_Post_BadRequest_BadBookingEnd {
            get {
                return ResourceManager.GetString("BookRoom_Post_BadRequest_BadBookingEnd", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This room is already booked for the given date..
        /// </summary>
        internal static string BookRoom_Post_BadRequest_Conflict {
            get {
                return ResourceManager.GetString("BookRoom_Post_BadRequest_Conflict", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cannot book a room for a past date..
        /// </summary>
        internal static string BookRoom_Post_BadRequest_PastBooking {
            get {
                return ResourceManager.GetString("BookRoom_Post_BadRequest_PastBooking", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The given room cannot hold the amount of guests requested..
        /// </summary>
        internal static string BookRoom_Post_BadRequest_TooManyGuests {
            get {
                return ResourceManager.GetString("BookRoom_Post_BadRequest_TooManyGuests", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The given room ID was not found..
        /// </summary>
        internal static string BookRoom_Post_NotFound_BadRoom {
            get {
                return ResourceManager.GetString("BookRoom_Post_NotFound_BadRoom", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to create the requested booking due to an internal server error..
        /// </summary>
        internal static string BookRoom_Post_ServerError_BookingFailed {
            get {
                return ResourceManager.GetString("BookRoom_Post_ServerError_BookingFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please provide a valid hotel name..
        /// </summary>
        internal static string HotelInfo_Get_BadRequest_EmptyName {
            get {
                return ResourceManager.GetString("HotelInfo_Get_BadRequest_EmptyName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No hotels could be found with a name containing your search term..
        /// </summary>
        internal static string HotelInfo_Get_NotFound_NoDbMatch {
            get {
                return ResourceManager.GetString("HotelInfo_Get_NotFound_NoDbMatch", resourceCulture);
            }
        }
    }
}
