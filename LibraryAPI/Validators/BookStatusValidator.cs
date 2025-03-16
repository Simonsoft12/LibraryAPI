using LibraryAPI.Enums;

namespace LibraryAPI.Validators
{
    public static class BookStatusValidator
    {
        public static bool IsStatusTransitionValid(BookStatus currentStatus, BookStatus newStatus)
        {
            switch (newStatus)
            {
                case BookStatus.OnShelf:
                    return currentStatus == BookStatus.Returned || currentStatus == BookStatus.Damaged;
                case BookStatus.Borrowed:
                    return currentStatus == BookStatus.OnShelf;
                case BookStatus.Returned:
                    return currentStatus == BookStatus.Borrowed;
                case BookStatus.Damaged:
                    return currentStatus == BookStatus.OnShelf || currentStatus == BookStatus.Returned;
                default:
                    return false;
            }
        }
    }
}