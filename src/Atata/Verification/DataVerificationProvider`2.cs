﻿namespace Atata
{
    public class DataVerificationProvider<TData, TOwner> :
        VerificationProvider<DataVerificationProvider<TData, TOwner>, TOwner>,
        IDataVerificationProvider<TData, TOwner>
        where TOwner : PageObject<TOwner>
    {
        public DataVerificationProvider(IDataProvider<TData, TOwner> dataProvider)
        {
            DataProvider = dataProvider;
        }

        protected IDataProvider<TData, TOwner> DataProvider { get; private set; }

        IDataProvider<TData, TOwner> IDataVerificationProvider<TData, TOwner>.DataProvider => DataProvider;

        protected override TOwner Owner
        {
            get { return DataProvider.Owner; }
        }

        public NegationDataVerificationProvider Not => new NegationDataVerificationProvider(DataProvider, this);

        public class NegationDataVerificationProvider :
            NegationVerificationProvider<NegationDataVerificationProvider, TOwner>,
            IDataVerificationProvider<TData, TOwner>
        {
            internal NegationDataVerificationProvider(IDataProvider<TData, TOwner> dataProvider, IVerificationProvider<TOwner> verificationProvider)
                : base(verificationProvider)
            {
                DataProvider = dataProvider;
            }

            protected IDataProvider<TData, TOwner> DataProvider { get; private set; }

            IDataProvider<TData, TOwner> IDataVerificationProvider<TData, TOwner>.DataProvider => DataProvider;

            protected override TOwner Owner
            {
                get { return DataProvider.Owner; }
            }
        }
    }
}
